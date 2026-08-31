using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
