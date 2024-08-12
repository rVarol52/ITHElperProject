using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HtmlAgilityPack;
using ITHelper.Application.Business.Services;
using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using ITHelper.Infranstrucure.Entities;
using ITHelper.Infranstrucure.ViewModel.BlogViewModel;
using ITHelper.Infranstrucure.ViewModel.EtiketViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace ITHelper.Presantation.UI.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService<Blog> _blogService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEtiketService<Etiket> _etiketService;
        private readonly IBlogEtiketService<BlogEtiket> _blogEtiketService;


        public BlogController(IBlogService<Blog> blogService, IWebHostEnvironment hostingEnvironment, IEtiketService<Etiket> etiketService, IBlogEtiketService<BlogEtiket> blogEtiketService)
        {
            _blogService = blogService;
            _hostingEnvironment = hostingEnvironment;
            _etiketService = etiketService;
            _blogEtiketService = blogEtiketService;
        }


        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(CreateBlogViewModel model, List<int> SelectedEtiketler)
        {

            if (!ModelState.IsValid)
            {
                return View(model); // Hataları göstererek formu yeniden döndür
            }


            var olusturanKullaniciID = HttpContext.Session.GetString("KullaniciID");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(model.Icerik);
            var plainText = htmlDoc.DocumentNode.InnerText;

            var newBlog = new Blog
            {
                Icerik = model.Icerik,
                Baslik = model.Baslik,
                Ozet = plainText.Length > 200 ? plainText.Substring(0, 200) + "..." : plainText,
                OlusturanKullaniciID = Convert.ToInt32(olusturanKullaniciID),

            };

            var result = _blogService.Add(newBlog);

            if (result > 0)
            {
                foreach (var etiketID in SelectedEtiketler)
                {
                    var blogEtiket = new BlogEtiket
                    {
                        BlogID = result,
                        EtiketID = etiketID,
                    };
                    _blogEtiketService.Add(blogEtiket);
                }
            }



            return View("Index");
        }

        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            var FileDicMain = "wwwroot/images/BlogImages";

            string FilePath = Path.Combine(_hostingEnvironment.ContentRootPath, FileDicMain);

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            string uzanti = file.FileName.Split('.').Last();

            var _filePath = Path.Combine(FilePath, file.FileName);
            using FileStream fs = System.IO.File.Create(_filePath);
            file.CopyTo(fs);
            return Ok();
        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blog = _blogService.GetByID(id);
            if (blog == null)
            {
                return NotFound();
            }

            var viewModel = new UpdateBlogViewModel
            {
                BlogID = blog.BlogID,
                Baslik = blog.Baslik,
                Icerik = blog.Icerik,
                BlogEtiketler = blog.BlogEtiketler,
            };

            var etiketler = _etiketService.GetListAll().Where(x => !viewModel.BlogEtiketler.Select(y => y.EtiketID).Contains(x.EtiketID));

            ViewBag.Etiketler = etiketler;


            return View(viewModel);

        }

        [HttpPost]
        public IActionResult EditBlog(UpdateBlogViewModel model, List<int> SelectedEtiketler)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(model.Icerik);
            var plainText = htmlDoc.DocumentNode.InnerText;
            if (ModelState.IsValid)
            {
                var blog = _blogService.GetByID(model.BlogID);
                blog.Baslik = model.Baslik;
                blog.Icerik = model.Icerik;
                //blog.BlogEtiketler=model.BlogEtiketler;
                blog.Ozet = plainText.Length > 200 ? plainText.Substring(0, 200) + "..." : plainText;

                // Mevcut etiketleri sil
                _blogEtiketService.RemoveBlogEtiketler(blog.BlogID);

                // Yeni etiketleri ekle
                foreach (var etiketID in SelectedEtiketler)
                {
                    var blogEtiket = new BlogEtiket
                    {
                        BlogID = blog.BlogID,
                        EtiketID = etiketID
                    };
                    _blogEtiketService.Add(blogEtiket);
                }



                _blogService.Update(blog);
                return RedirectToAction("Bloglarım");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Bloglar()
        {


            //var bloglar = _blogService.GetListAll()
            //    .Select(x => new ResultBlogViewModel
            //    {
            //        BlogID = x.BlogID,
            //        Icerik = x.Icerik,
            //        Baslik = x.Baslik,
            //    })
            //    .ToList();
            //var viewModel = new ResultBlogViewModel
            //{
            //    Blogs = bloglar
            //};
            return View();
            //return Json(DataSourceLoader.Load(bloglar, loadOption));

        }


        [HttpGet]
        public object BlogList(DataSourceLoadOptions loadOptions)
        {

            var bloglar = _blogService.GetListAll()
              .Select(x => new ResultBlogViewModel
              {
                  BlogID = x.BlogID,
                  Icerik = x.Icerik,
                  Baslik = x.Baslik,
                  Ozet = x.Ozet,
                  OlusturulmaTarihi = x.OlusturulmaTarihi,
                  OlusturanKullaniciAdi = x.OlusturanKullanici.KullaniciAdi,
                  OlusturanKullaniciSoyadi = x.OlusturanKullanici.KullaniciSoyadi
              })
              .ToList();
            var viewModel = new ResultBlogViewModel
            {
                Blogs = bloglar
            };

            return DataSourceLoader.Load(bloglar, loadOptions);
        }

        [HttpGet]
        public ActionResult Bloglarım()
        {
            //var olusturanKullanici = HttpContext.Session.GetString("KullaniciID");
            //var bloglar = _blogService.GetListAll().Where(x => x.OlusturanKullaniciID == Convert.ToInt32(olusturanKullanici)).Select(x => new ResultBlogViewModel()
            //{
            //    BlogID = x.BlogID,
            //    Icerik = x.Icerik,
            //    Baslik = x.Baslik,
            //    OlusturulmaTarihi = x.OlusturulmaTarihi,
            //    OlusturanKullaniciAdi = x.OlusturanKullanici.KullaniciAdi,
            //    OlusturanKullaniciSoyadi = x.OlusturanKullanici.KullaniciSoyadi
            //}).ToList();
            //ResultBlogViewModel returnModel = new ResultBlogViewModel()
            //{
            //    Blogs = bloglar
            //};

            //return View(returnModel);

            return View();


        }

        [HttpGet]
        public object BloglarımList(DataSourceLoadOptions loadOptions)
        {
            var olusturanKullanici = HttpContext.Session.GetString("KullaniciID");
            var bloglar = _blogService.GetListAll().Where(x => x.OlusturanKullaniciID == Convert.ToInt32(olusturanKullanici)).Select(x => new ResultBlogViewModel()
            {
                BlogID = x.BlogID,
                Icerik = x.Icerik,
                Baslik = x.Baslik,
                Ozet = x.Ozet,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                OlusturanKullaniciAdi = x.OlusturanKullanici.KullaniciAdi,
                OlusturanKullaniciSoyadi = x.OlusturanKullanici.KullaniciSoyadi
            }).ToList();
            ResultBlogViewModel returnModel = new ResultBlogViewModel()
            {
                Blogs = bloglar
            };

            return DataSourceLoader.Load(bloglar, loadOptions);
        }

        [HttpGet]
        public IActionResult BlogDetay(int id)
        {
            _blogService.ArtirOkunmaSayisi(id);
            var blog = _blogService.GetByID(id);
            var viewModel = new ResultBlogViewModel
            {
                BlogID = blog.BlogID,
                Baslik = blog.Baslik,
                Icerik = blog.Icerik,
                OlusturulmaTarihi = blog.OlusturulmaTarihi,
                OlusturanKullaniciAdi = blog.OlusturanKullanici.KullaniciAdi,
                OlusturanKullaniciSoyadi = blog.OlusturanKullanici.KullaniciSoyadi,
                BlogEtiktler = blog.BlogEtiketler,
                OkunmaSayisi = blog.OkunmaSayisi,

            };

            return View(viewModel);

        }


        public IActionResult GetEtiketler()
        {
            var etiketler = _etiketService.GetListAll()
                .Select(x => new ResultEtiketViewModel
                {
                    EtiketAdi = x.EtiketAdi,
                    EtiketID = x.EtiketID,
                }).ToList();

            return Json(etiketler);
        }

        [HttpPost]
        public IActionResult AddEtiket(CreateEtiketViewModel model)
        {
            var newEtiket = new Etiket
            {
                EtiketAdi = model.EtiketAdi,
            };

            var result = _etiketService.Add(newEtiket);
            newEtiket.EtiketID = result;

            return Json(newEtiket);
        }


        public class DenemeEtiket
        {
            int id { get; set; }
        }

        [HttpGet]
        public ActionResult FilterBlogs(string etiketler)
        {
            try
            {

                List<string> stringList = JsonConvert.DeserializeObject<List<string>>(etiketler);

                if (stringList.Any())
                {
                    List<int> intList = stringList.ConvertAll(int.Parse);
                    var blogs = _blogService.GetBlogsByEtiketler(intList).Select(x => new ResultBlogViewModel
                    {
                        BlogID = x.BlogID,
                        Icerik = x.Icerik,
                        Baslik = x.Baslik,
                        Ozet = x.Ozet,
                        OlusturulmaTarihi = x.OlusturulmaTarihi,
                        OlusturanKullaniciAdi = x.OlusturanKullanici.KullaniciAdi,
                        OlusturanKullaniciSoyadi = x.OlusturanKullanici.KullaniciSoyadi
                    })
                  .ToList();
                    return Json(blogs);
                }
                else
                {
                    var blogs = _blogService.GetListAll().Select(x => new ResultBlogViewModel
                    {
                        BlogID = x.BlogID,
                        Icerik = x.Icerik,
                        Baslik = x.Baslik,
                        Ozet = x.Ozet,
                        OlusturulmaTarihi = x.OlusturulmaTarihi,
                        OlusturanKullaniciAdi = x.OlusturanKullanici.KullaniciAdi,
                        OlusturanKullaniciSoyadi = x.OlusturanKullanici.KullaniciSoyadi
                    })
                 .ToList();
                    return Json(blogs);
                }

            }
            catch (Exception ex)
            {
                // Log exception or handle error
                return Json(new { success = false, message = "Blog yüklenemedi." });
            }
        }




    }
}
