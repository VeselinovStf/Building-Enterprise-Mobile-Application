using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Exceptions;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests
{
    [TestFixture]
    public class CatalogDataService_Should
    {
        [Test]
        public async Task GetAllPiesAsync()
        {
            var requestProviderMock = new Mock<IRequestProvider>();
                requestProviderMock
                    .Setup(e => e.GetAsync<IList<Pie>>(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<IList<Pie>>(PieList.MockPieCatalog()));

            var casheMock = new Mock<IBaseCacheStrategy>();

            ICatalogDataService dataService 
                = new CatalogDataService(requestProviderMock.Object, casheMock.Object);

            var serviceCallResult = await dataService.GetAllPiesAsync();

            Assert.IsNotNull(serviceCallResult);
            Assert.AreEqual(PieList.MockPieCatalogCount(), serviceCallResult.Count);
        }

        [Test]
        public void GetAllPiesAsync_Throws_Exception_When_RequestProvider_Thhrows_Exception()
        {
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.GetAsync<IList<Pie>>(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new ArgumentException());

            var casheMock = new Mock<IBaseCacheStrategy>();

            ICatalogDataService dataService
                = new CatalogDataService(requestProviderMock.Object, casheMock.Object);
         
              Assert.ThrowsAsync<DataServiceException>(async() => await dataService.GetAllPiesAsync());          
        }
    }
}
