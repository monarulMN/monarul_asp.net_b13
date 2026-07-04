using DevSkill.Shop.Application.Features.Categories.Command;
using DevSkill.Shop.Domain.Entities;
using Mapster;

namespace DevSkill.Shop.Web
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryAddCommand, Category>();
        }
    }
}
