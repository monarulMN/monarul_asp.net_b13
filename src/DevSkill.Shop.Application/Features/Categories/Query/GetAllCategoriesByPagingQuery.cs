using Cortex.Mediator.Queries;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Categories.Query
{
    public class GetAllCategoriesByPagingQuery : IQuery<(IList<Category>, int, int)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public string SortText { get; set; }
    }
}
