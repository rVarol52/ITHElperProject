using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.Entities;
using ITHelper.Infranstrucure.ViewModel.BlogViewModel;
using ITHelper.Presantation.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITHelper.Presantation.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBlogService<Blog> _blogService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            var kullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            ViewBag.KullaniciAdi = kullaniciAdi;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
