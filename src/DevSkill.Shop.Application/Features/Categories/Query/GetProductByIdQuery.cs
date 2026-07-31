using Cortex.Mediator.Queries;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Query
{
    public class GetProductByIdQuery : IQuery<Category?>
    {
        public Guid Id { get; set; }
    }
}
