using Microsoft.AspNetCore.Mvc;
using RAFWEB.Core;

namespace RAFWEB.API.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationContext _db;

        public EventController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var ObjEventList = _db.Holiday.ToList();
            return View();
        }
        
        
    }
}
