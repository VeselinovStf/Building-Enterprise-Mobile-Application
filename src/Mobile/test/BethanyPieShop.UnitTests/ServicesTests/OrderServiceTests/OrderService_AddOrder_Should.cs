using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Models;
using BethanyPieShop.Core.Services.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.UnitTests.ServicesTests.OrderServiceTests
{
    [TestFixture]
    public class OrderService_AddOrder_Should
    {
        [Test]
        public async Task Returns_AddedOrder_When_Correct_Parrameters_Are_Passed()
        {
            var orderTotal = 123;
            var userId = "U1";
            var orderId = "O1";
            var singlePie = PieListMock
                        .MockPieCatalog()
                        .ToList()
                        .FirstOrDefault();

            var orderAddressCity = "City";
            var orderAddressNumber = "+123456778";
            var orderAddressStreet = "SampleStreet";
            var orderAddressZipCode = "5100";

            var pies = new List<Pie>()
            {
                singlePie
            };

            var orderAddress = new Address()
            {
                City = orderAddressCity,
                Number = orderAddressNumber,
                Street = orderAddressStreet,
                ZipCode = orderAddressZipCode
            };

            var order = new Order()
            {
                Address = orderAddress,
                OrderTotal = orderTotal,
                Pies = pies,
                UserId = userId,
                OrderId = orderId
            };

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock
                .Setup(e => e.PostAsync<Order>(It.IsAny<string>(), It.IsAny<Order>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Order>(order));

            var orderDataService = new OrderDataService(requestProviderMock.Object);

            var addedOrderResult = await orderDataService.AddOrderAsync(order);

            Assert.NotNull(addedOrderResult);
            Assert.NotNull(addedOrderResult.Address);
            Assert.NotNull(addedOrderResult.Pies);

            Assert.AreEqual(addedOrderResult.OrderTotal, orderTotal);
            Assert.AreEqual(addedOrderResult.UserId, userId);
            Assert.AreEqual(addedOrderResult.OrderId, orderId);

            var orderAddedAddress = addedOrderResult.Address;

            Assert.AreEqual(orderAddedAddress.City, orderAddressCity);
            Assert.AreEqual(orderAddedAddress.Number, orderAddressNumber);
            Assert.AreEqual(orderAddedAddress.Street, orderAddressStreet);
            Assert.AreEqual(orderAddedAddress.ZipCode, orderAddressZipCode);

            var orderAddedPies = addedOrderResult.Pies;

            Assert.AreEqual(orderAddedPies.Count, 1);

            var orderAddedPie = orderAddedPies.FirstOrDefault();

            Assert.AreEqual(orderAddedPie.ImageThumbnailUrl, singlePie.ImageThumbnailUrl);
            Assert.AreEqual(orderAddedPie.ImageUrl, singlePie.ImageUrl);
            Assert.AreEqual(orderAddedPie.InStock, singlePie.InStock);
            Assert.AreEqual(orderAddedPie.IsPieOfTheWeek, singlePie.IsPieOfTheWeek);
            Assert.AreEqual(orderAddedPie.LongDescription, singlePie.LongDescription);
            Assert.AreEqual(orderAddedPie.Name, singlePie.Name);
            Assert.AreEqual(orderAddedPie.PieId, singlePie.PieId);
            Assert.AreEqual(orderAddedPie.Price, singlePie.Price);
            Assert.AreEqual(orderAddedPie.ShortDescription, singlePie.ShortDescription);
            Assert.AreEqual(orderAddedPie.AllergyInformation, singlePie.AllergyInformation);
            

        }
    }
}
