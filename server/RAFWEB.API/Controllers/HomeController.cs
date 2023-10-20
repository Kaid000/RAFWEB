using Microsoft.AspNetCore.Mvc;

namespace RAFWEB.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
