using Cortex.Mediator;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Categories.Command;
using DevSkill.Shop.Application.Features.Categories.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using DevSkill.Shop.Infrastructure.Extensions;
using DevSkill.Shop.Web.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using DevSkill.Shop.Infrastructure.Extensions;
using DevSkill.Shop.Web.Codes;
using DevSkill.Shop.Application.Exceptions;

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


        public IActionResult Create()
        {
            var model = new CategoryCreateModel();
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var command = _mapper.Map<CategoryAddCommand>(model);
                    var category = await _mediator.SendCommandAsync(command);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Category successfully created",
                            Type = ResponseTypes.Success
                        });

                    return RedirectToAction(nameof(Index));
                }
                catch(DuplicateDataException oex)
                {
                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = oex.Message,
                            Type = ResponseTypes.Danger
                        });
                }
                catch (Exception ex)
                {
                    const string errorMessage = "Failed to create category";

                    _logger.LogError(ex, errorMessage);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = errorMessage,
                            Type = ResponseTypes.Danger
                        });
                                        
                }
                
            }
            else
            {
                TempData.Put(Constants.ResponseTempKey,
                     new ResponseModel
                     {
                         Message = "Please provide all information.",
                         Type = ResponseTypes.Success
                     });
            }
            return View(model);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get category list");

                return Json(DataTables.EmptyResult);
            }
        }

    }
}
