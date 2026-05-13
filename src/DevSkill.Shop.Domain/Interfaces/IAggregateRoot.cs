using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Interfaces
{
    public interface IAggregateRoot<TKey>
    {
        TKey Id { get; set; }
    }
}
