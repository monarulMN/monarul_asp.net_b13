using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data.Repositories
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
