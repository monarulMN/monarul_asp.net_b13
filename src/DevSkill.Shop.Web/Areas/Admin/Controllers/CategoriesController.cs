using Cortex.Mediator;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Categories.Command;
using DevSkill.Shop.Application.Features.Categories.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using DevSkill.Shop.Web.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

        [HttpPost]
        public async Task<JsonResult> GetPagedCategories([FromBody] CategoryListModel model)
        {

            try
            {
                var query = _mapper.Map<GetAllCategoriesByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "IsActive", "ImageName");

                var (items, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllCategoriesByPagingQuery, 
                    (IList<Category>, int, int)>(query);

                var category = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(item.Name),
                                item.IsActive.ToString(),
                                HttpUtility.HtmlEncode(item.ImageName),
                                item.Id.ToString()
                            }).ToArray()
                };

                return Json(category);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to get category list");

                return Json(DataTables.EmptyResult);
            }

            //return Json(new
            //{
            //    recordsTotal = 0,
            //    recordsFiltered = 0,
            //    data = (new string[] { }).ToArray()
            //});
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
