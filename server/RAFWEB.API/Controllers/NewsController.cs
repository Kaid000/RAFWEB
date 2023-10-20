using Microsoft.AspNetCore.Mvc;

namespace RAFWEB.API.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
