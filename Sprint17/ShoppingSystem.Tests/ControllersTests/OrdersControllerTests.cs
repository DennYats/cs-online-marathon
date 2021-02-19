using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ShoppingSystem.Services;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using System.Threading.Tasks;
using System;
using FluentAssertions;

namespace ShoppingSystem.Tests.ControllersTests
{
    public class OrdersControllerTests
    {
        Mock<IOrders> mock = new Mock<IOrders>();
        OrdersController controller;

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfOrders()
        {
            // Arrange
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestOrders());
            controller = new OrdersController(mock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Order>>(viewResult.Model);
            Assert.Equal(GetTestOrders().Count, model.Count());
            GetTestOrders().Should().BeEquivalentTo(model);
        }

        private List<Order> GetTestOrders()
        {
            var orders = new List<Order>
            {
                new Order {CustomerId = 1, SupermarketId = 2, OrderDate = DateTime.Parse("5-6-2020")},
                new Order {CustomerId = 2, SupermarketId = 3, OrderDate = DateTime.Parse("2-11-2018")},
                new Order {CustomerId = 3, SupermarketId = 4, OrderDate = DateTime.Parse("7-7-2020")},
                new Order {CustomerId = 4, SupermarketId = 2, OrderDate = DateTime.Parse("1-8-2020")},
            };

            return orders;
        }

        [Fact]
        public async Task Details_Returns_ViewResult_OrderByID()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(order);
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
            order.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async Task Details_Return_BadRequestResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).Throws(new Exception());
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Create_OrderReturns_RedirectToActionResult()
        {
            controller = new OrdersController(mock.Object);
            Order newOrder = new Order
            { CustomerId = 1, SupermarketId = 2, OrderDate = DateTime.Parse("5-6-2020") };

            var result = await controller.Create(newOrder);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.AddAsync(newOrder));
        }

        //POST
        [Fact]
        public async Task Create_OrderReturns_ViewResult()
        {
            Order newOrder = new Order();

            mock.Setup(repo => repo.AddAsync(newOrder)).Throws(new Exception());
            controller = new OrdersController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.Create(newOrder);

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //GET
        [Fact]
        public async Task Edit_Returns_OrderInfoForEditing()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock
                .Setup(repo => repo.GetByIdAsync(order.Id)).ReturnsAsync(order);
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Edit(order.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        //GET
        [Fact]
        public async Task Edit_Returns_BadRequestResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock
                .Setup(repo => repo.GetByIdAsync(order.Id))
                .ThrowsAsync(new Exception());
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Edit(order.Id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_RedirectToActionResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(order));
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Edit(id, order);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.EditAsync(order));
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_BadRequestResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(order))
                .ThrowsAsync(new Exception());
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Edit(id, order);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);

        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <returns></returns>
        //GET
        [Fact]
        public async Task Delete_Returns_RedirectToActionResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(order.Id));
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Delete(order.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }
        //GET
        [Fact]
        public async Task Delete_ReturnsOrderInfoForDeleting()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(order.Id)).Throws(new Exception());
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.Delete(order.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //POST
        [Fact]
        public async Task DeletePOST_Returns_RedirectToActionResult()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(order.Id));
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(order.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.DeleteAsync(order.Id));
        }
        //POST
        [Fact]
        public async Task DeletePOST_Returns_OrdernfoForDeleting()
        {
            int id = 1;
            var order = GetTestOrders().FirstOrDefault(o => o.CustomerId == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(order.Id)).Throws(new Exception());
            controller = new OrdersController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(order.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
