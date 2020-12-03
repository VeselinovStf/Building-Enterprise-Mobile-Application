using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.CatalogServiceTests
{
    [TestFixture]
    public class CatalogDataService_GetPiesOfTheWeekAsync_Should
    {
        [Test]
        public async Task GetAllPiesOfTheWeekAsync()
        {
            var requestProviderMock = new Mock<IRequestProvider>();

            var piesOfTheWeek = PieListMock.MockPieCatalog().Where(p => p.IsPieOfTheWeek == true).ToList();

            requestProviderMock
                .Setup(e => e.GetAsync<List<Pie>>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<List<Pie>>(piesOfTheWeek));

            var casheMock = new Mock<IBaseCacheStrategy>();

            ICatalogDataService dataService
                = new CatalogDataService(requestProviderMock.Object, casheMock.Object);

            var serviceCallResult = await dataService.GetPiesOfTheWeekAsync();

            Assert.IsNotNull(serviceCallResult);
            Assert.AreEqual(piesOfTheWeek.Count, serviceCallResult.ToList().Count);
        }

        [Test]
        public void Throws_Exception_When_RequestProvider_Thhrows_Exception()
        {
            var requestProviderMock = new Mock<IRequestProvider>();

            var piesOfTheWeek = PieListMock.MockPieCatalog().Where(p => p.IsPieOfTheWeek == true).ToList();

            requestProviderMock
                .Setup(e => e.GetAsync<IList<Pie>>(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new ArgumentException());

            var casheMock = new Mock<IBaseCacheStrategy>();

            ICatalogDataService dataService
                = new CatalogDataService(requestProviderMock.Object, casheMock.Object);

            Assert.ThrowsAsync<CatalogDataServiceException>(async () => await dataService.GetPiesOfTheWeekAsync());
        }

    }
}
