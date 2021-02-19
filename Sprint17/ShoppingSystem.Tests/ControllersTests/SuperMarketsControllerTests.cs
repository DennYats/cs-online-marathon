using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingSystem.Tests.ControllersTests
{
    public class SuperMarketsControllerTests
    {
        Mock<ISupermarkets> mock = new Mock<ISupermarkets>();
        SupermarketsController controller;

        /// <summary>
        /// Index method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Index_Returns_AListOfProducts()
        {
            // Arrange
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetSupermarkets());
            controller = new SupermarketsController(mock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Supermarket>>(viewResult.ViewData.Model);
            GetSupermarkets().Should().BeEquivalentTo(model);
        }
        private List<Supermarket> GetSupermarkets()
        {
            var markets = new List<Supermarket>()
            {
                new Supermarket{ Id = 1, Name = "market1", Address = "lol" },
                new Supermarket{ Id = 2, Name = "market2", Address = "lol" },
                new Supermarket{ Id = 3, Name = "market3", Address = "lol" },
                new Supermarket{ Id = 4, Name = "market4", Address = "lol" }
            };
            return markets;
        }

        /// <summary>
        /// Details method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Details_Returns_ViewResult_ProductByID()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(market);
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Supermarket>(viewResult.ViewData.Model);
            market.Should().BeEquivalentTo(model);
        }
        [Fact]
        public async Task Details_Returns_BadRequestResult()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).Throws(new Exception());
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
        //POST
        [Fact]
        public async Task Create_ProductReturns_RedirectToActionResult()
        {
            mock = new Mock<ISupermarkets>();
            controller = new SupermarketsController(mock.Object);
            Supermarket newProduct = new Supermarket
            {
                Name = "Bread",
                Address = "lol"
            };

            var result = await controller.Create(newProduct);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.AddAsync(newProduct));
        }

        //POST
        [Fact]
        public async Task Create_ProductReturns_ViewResult()
        {
            Supermarket newProduct = new Supermarket();

            mock = new Mock<ISupermarkets>();
            mock.Setup(repo => repo.AddAsync(newProduct)).Throws(new Exception());
            controller = new SupermarketsController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.Create(newProduct);

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// Edit method
        /// </summary>
        /// <returns></returns>
        //GET
        [Fact]
        public async Task Edit_Returns_ProductInfoForEditing()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock
                .Setup(repo => repo.GetByIdAsync(market.Id)).ReturnsAsync(market);
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Edit(market.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        //GET
        [Fact]
        public async Task Edit_Returns_BadRequestResult()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock
                .Setup(repo => repo.GetByIdAsync(market.Id))
                .ThrowsAsync(new Exception());
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Edit(market.Id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(market));
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Edit(id, market);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.EditAsync(market));
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_BadRequestResult()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(market))
                .ThrowsAsync(new Exception());
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Edit(id, market);

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
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(market.Id));
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Delete(market.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }
        //GET
        [Fact]
        public async Task Delete_Returns_ProductInfoForDeleting()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(market.Id)).Throws(new Exception());
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.Delete(market.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        
        //POST
        [Fact]
        public async Task DeletePOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var market = GetSupermarkets().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(market.Id));
            controller = new SupermarketsController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(market.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.DeleteAsync(market.Id));
        }
    }
}
