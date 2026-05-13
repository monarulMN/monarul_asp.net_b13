using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
