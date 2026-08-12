using Microsoft.AspNetCore.Mvc;

namespace MaleFashion.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
