using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using ITHelper.Infranstrucure.Entities;
using ITHelper.Infranstrucure.ViewModel.KullaniciViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ITHelper.Presantation.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ITHelperContext _context;
        private readonly IKullaniciService<Kullanici> _kullaniciService;

        public LoginController(ITHelperContext context, IKullaniciService<Kullanici> kullaniciService) 
        {
            _kullaniciService = kullaniciService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ResultKullaniciViewModel model)
        {

            var user = _context.Kullanicilar.FirstOrDefault(u => u.KullaniciMail == model.KullaniciMail && u.KullaniciSifresi == model.KullaniciSifresi);
            if (user != null)
            {
                HttpContext.Session.SetString("KullaniciAdi", user.KullaniciAdi);
                HttpContext.Session.SetString("KullaniciSoyadi", user.KullaniciSoyadi);
                HttpContext.Session.SetString("KullaniciID", user.KullaniciID.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Geçersiz email veya şifre.";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Register(CreateKullaniciViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.KullaniciSifresi != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Şifre ve şifre doğrulama eşleşmiyor.");
                return View(model);
            }

            var existingUser = _kullaniciService.GetListAll().FirstOrDefault(u => u.KullaniciMail == model.KullaniciMail);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu email adresi zaten kullanılıyor.");
                return View(model);
            }

            var newUser = new Kullanici
            {
                KullaniciAdi = model.KullaniciAdi,
                KullaniciSoyadi = model.KullaniciSoyadi,
                KullaniciMail = model.KullaniciMail,
                KullaniciSifresi = model.KullaniciSifresi,
                KullaniciAktifligi = false
            };

            _kullaniciService.Add(newUser);

            return RedirectToAction("Index", "Login");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Index", "Login");
        }

    }
}
