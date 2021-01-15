namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> FindAllAsync(int pageIndex);
        Task<Pie> FindByIdAsync(Guid id);
        Task<Pie> SaveAsync(Pie pie);
    }
}