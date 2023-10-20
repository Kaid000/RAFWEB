using Microsoft.AspNetCore.Mvc;

namespace RAFWEB.API.Controllers
{
    public class StudentOrganizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
