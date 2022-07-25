namespace Bakery.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Bakery.Domain.Aggregates.PieAggregate;

    public class PieRepository: IPieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PieRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Pie>> FindAllAsync(int pageIndex)
        {
            return await _applicationDbContext.Pies
                .OrderBy(x => x.Name)
                .Skip(pageIndex * 10)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Pie> FindByIdAsync(Guid id)
        {
            return await _applicationDbContext.Pies
                .Include(x => x.Portions).AsSplitQuery()
                .Include(x => x.Ingredients).AsSplitQuery()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pie> SaveAsync(Pie pie)
        {
            await _applicationDbContext.Pies.AddAsync(pie);
            await _applicationDbContext.SaveChangesAsync();

            return pie;
        }
    }
}