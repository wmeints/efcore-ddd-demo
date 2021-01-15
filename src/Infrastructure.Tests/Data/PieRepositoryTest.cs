namespace Bakery.Infrastructure.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Bakery.Infrastructure.Data;
    using Xunit;


    public class PieRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly IPieRepository _pieRepository;
        private readonly DatabaseFixture _databaseFixture;

        public PieRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _pieRepository = new PieRepository(_databaseFixture.DbContext);
        }

        [Fact]
        public async Task SaveAsync_InsertsPieInTheDatabase()
        {
            var pie = Pie.Create("Apple pie", "Awesome apple pie", new Portions(8, 10));
            var savedPie = await _pieRepository.SaveAsync(pie);

            Assert.NotNull(savedPie);
            Assert.NotNull(_databaseFixture.DbContext.Pies.SingleOrDefault(x => x.Id == pie.Id));
        }

        [Fact]
        public async Task FindAllAsync_ReturnsAllPies()
        {
            await _pieRepository.SaveAsync(Pie.Create("Apple pie", "Awesome apple pie", new Portions(8, 10)));
            await _pieRepository.SaveAsync(Pie.Create("Cherry pie", "Awesome cherry pie", new Portions(8, 10)));
            await _pieRepository.SaveAsync(Pie.Create("Blackforest pie", "Some pie from germany, pretty delicious", new Portions(8, 10)));

            var pies = await _pieRepository.FindAllAsync(0);

            Assert.NotNull(pies);
            Assert.Equal(3, pies.Count());
        }

        [Fact]
        public async Task FindById_ReturnsExistingPies()
        {
            var expectedPie = Pie.Create("Apple pie", "Awesome apple pie", new Portions(8, 10));

            await _pieRepository.SaveAsync(expectedPie);

            var actualPie = await _pieRepository.FindByIdAsync(expectedPie.Id);

            Assert.NotNull(actualPie);
        }
    }
}