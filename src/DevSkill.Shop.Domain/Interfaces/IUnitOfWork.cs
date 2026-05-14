using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
