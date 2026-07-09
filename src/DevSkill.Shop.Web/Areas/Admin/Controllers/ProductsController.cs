using Cortex.Mediator;
using DevSkill.Shop.Application.Exceptions;
using DevSkill.Shop.Application.Features.Products.Command;
using DevSkill.Shop.Application.Features.Products.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using DevSkill.Shop.Infrastructure.Extensions;
using DevSkill.Shop.Web.Areas.Admin.Models;
using DevSkill.Shop.Web.Areas.Admin.Models.Products;
using DevSkill.Shop.Web.Codes;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator, IMapper mapper)
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
            var model = new ProductCreateModel();
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = _mapper.Map<ProductAddCommand>(model);
                    var product = await _mediator.SendCommandAsync(command);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Product successfully created",
                            Type = ResponseTypes.Success
                        });

                    return RedirectToAction(nameof(Index));
                }
                catch (DuplicateDataException oex)
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
                    const string errorMessage = "Failed to create Product";

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
        public async Task<JsonResult> GetPagedProducts([FromBody] ProductListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllProductsByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "Price", "IsActive", "Brand", "Sku", "Color", "Weight");

                var (items, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllProductsByPagingQuery,
                    (IList<Product>, int, int)>(query);

                var product = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(item.Name),
                                item.Price.ToString("0.00"),
                                item.IsActive.ToString(),
                                HttpUtility.HtmlEncode(item.Brand),
                                HttpUtility.HtmlEncode(item.Sku),
                                HttpUtility.HtmlEncode(item.Color),
                                item.Weight.ToString("0.00"),
                                item.Id.ToString()
                            }).ToArray()
                };

                return Json(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get product list");

                return Json(DataTables.EmptyResult);
            }
        }
    }
}
