using Cortex.Mediator;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Categories.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetPagedCategories( object o)
        {
            return Json(new
            {
                recordsTotal = 0,
                recordsFiltered = 0,
                data = (new string[] { }).ToArray()
            });
        }

        //public IActionResult Create()
        //{
        //    var model = new CategoryAddCommand();
        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoryAddCommand model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var category = await _mediator.SendCommandAsync(model);
        //    return RedirectToAction("Index");
        //}
    }
}
