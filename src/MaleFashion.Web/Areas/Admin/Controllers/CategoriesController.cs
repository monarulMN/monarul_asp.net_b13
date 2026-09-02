using Cortex.Mediator;
using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Domain.Utilities;
using MaleFashion.Web.Areas.Admin.Models.Categories;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MaleFashion.Domain.Entities;
using System.Web;
using MaleFashion.Infrastructure.Extensions;
using MaleFashion.Web.Areas.Admin.Models;
using MaleFashion.Web.Codes;
using MaleFashion.Application.Features.Categories.Command;
using MaleFashion.Application.Exceptions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MaleFashion.Application.Contracts.Services;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public CategoriesController(ILogger<CategoriesController> logger, 
            IMediator mediator, 
            IMapper mapper, 
            IFileStorageService fileStorageService)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Create()
        
        {
            var model = new CategoryCreateModel();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string? imageUrl = null;
                    if(model.ImageUrl is not null)
                    {
                        await using var stream = model.ImageUrl.OpenReadStream();

                        imageUrl = await _fileStorageService.SaveImageAsync(
                            stream,
                            model.ImageUrl.FileName,
                            "categories",
                            cancellationToken
                        );
                    }
                    var createCommand = _mapper.Map<CategoryAddCommand>(model);
                    var result = await _mediator.SendCommandAsync(createCommand);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Category created successfully!",
                            Type = ResponseTypes.Success
                        });

                    return RedirectToAction(nameof(Index));
                }
                catch (DuplicateDataException oex)
                {
                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Category already exists!",
                            Type = ResponseTypes.Danger
                        });
                }
                catch (Exception ex)
                {
                    const string errorMessage = "Failed to create category!";

                    _logger.LogError(ex, errorMessage);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = errorMessage,
                            Type = ResponseTypes.Danger
                        });

                    return View(model);
                }
            }
            else
            {
                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = "Please provide all information.",
                        Type = ResponseTypes.Danger
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
                query.SortText = model.FormatSortExpression("ImageUrl", "Name", "Description", "IsActive");

                var (categories, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllCategoriesByPagingQuery, 
                    (IList<Category>, int, int)>(query);

                var categoryResult = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from categoty in categories
                            select new string[]
                            {
                                $"/uploads/categories/{HttpUtility.HtmlEncode(categoty.ImageUrl)}",
                                HttpUtility.HtmlEncode(categoty.Name),
                                HttpUtility.HtmlEncode(categoty.Description),
                                categoty.IsActive ? "Active" : "Inactive",
                                categoty.Id.ToString()
                            }).ToArray()
                };
                return Json(categoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get category list!");
                return Json(DataTables.EmptyResult);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleteCommand = new CategoryDeleteCommand { Id = id };
                await _mediator.SendCommandAsync(deleteCommand);

                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = "Category deleted successfully!",
                        Type = ResponseTypes.Success
                    });

            }
            catch(Exception ex)
            {
                const string errorMessage = "Failed to delete category!";

                _logger.LogError(ex, errorMessage);

                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = errorMessage,
                        Type = ResponseTypes.Danger
                    });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
