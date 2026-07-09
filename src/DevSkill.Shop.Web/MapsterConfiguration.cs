using DevSkill.Shop.Application.Features.Categories.Command;
using DevSkill.Shop.Application.Features.Products.Command;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Web.Areas.Admin.Models.Categories;
using DevSkill.Shop.Web.Areas.Admin.Models.Products;
using Mapster;

namespace DevSkill.Shop.Web
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryAddCommand, Category>();
            config.NewConfig<CategoryCreateModel, CategoryAddCommand>();

            config.NewConfig<ProductAddCommand, Product>();
            config.NewConfig<ProductCreateModel, ProductAddCommand>();
        }
    }
}
