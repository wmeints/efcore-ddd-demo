namespace Bakery.Infrastructure.Tests
{
    using System;
    using Bakery.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseFixture: IDisposable
    {
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            DbContext = new ApplicationDbContext(options);
        }

        public ApplicationDbContext DbContext {get; private set; }

        public void Dispose()
        {
            if(DbContext != null) 
            {
                DbContext.Dispose();
                DbContext = null;
            }
            
        }
    }
}