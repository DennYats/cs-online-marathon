using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System;

namespace ShoppingSystem.Tests.ControllersTests
{
    public class ProductsControllerTests
    {
        Mock<IProducts> mock = new Mock<IProducts>();
        ProductsController controller;

        /// <summary>
        /// Index method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Index_Returns_AListOfProducts()
        {
            // Arrange
            mock.Setup(p => p.GetAllAsync()).ReturnsAsync(GetProducts());
            controller = new ProductsController(mock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
            GetProducts().Should().BeEquivalentTo(model);
        }
        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product{ Id = 1, Name = "Cheese", Price = 30 },
                new Product{ Id = 2, Name = "Sausage", Price = 45 },
                new Product{ Id = 3, Name = "Bread", Price = 15 },
                new Product{ Id = 4, Name = "Milk", Price = 20 }
            };
            return products;
        }

        /// <summary>
        /// Details method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Details_Returns_ViewResult_ProductByID()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.GetByIdAsync(id)).ReturnsAsync(product);
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);
            product.Should().BeEquivalentTo(model);
        }
        [Fact]
        public async Task Details_Returns_BadRequestResult()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.GetByIdAsync(id)).Throws(new Exception());
            controller = new ProductsController(mock.Object);

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
            mock = new Mock<IProducts>();
            controller = new ProductsController(mock.Object);
            Product newProduct = new Product
            {
                Name = "Bread",
                Price = 15
            };

            var result = await controller.Create(newProduct);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(p => p.AddAsync(newProduct));
        }

        //POST
        [Fact]
        public async Task Create_ProductReturns_ViewResult()
        {
            Product newProduct = new Product();

            mock = new Mock<IProducts>();
            mock.Setup(p => p.AddAsync(newProduct)).Throws(new Exception());
            controller = new ProductsController(mock.Object);
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
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock
                .Setup(p => p.GetByIdAsync(product.Id)).ReturnsAsync(product);
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Edit(product.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        //GET
        [Fact]
        public async Task Edit_Returns_BadRequestResult()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock
                .Setup(p => p.GetByIdAsync(product.Id))
                .ThrowsAsync(new Exception());
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Edit(product.Id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.EditAsync(product));
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Edit(id, product);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(p => p.EditAsync(product));
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_BadRequestResult()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.EditAsync(product))
                .ThrowsAsync(new Exception());
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Edit(id, product);

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
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.DeleteAsync(product.Id));
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Delete(product.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        }
        //GET
        [Fact]
        public async Task Delete_Returns_ProductInfoForDeleting()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.DeleteAsync(product.Id)).Throws(new Exception());
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.Delete(product.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //POST
        [Fact]
        public async Task DeletePOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.DeleteAsync(product.Id));
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(product.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(p => p.DeleteAsync(product.Id));
        }
        //POST
        [Fact]
        public async Task DeletePOST_Returns_ProductInfoForDeleting()
        {
            int id = 4;
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(p => p.DeleteAsync(product.Id)).Throws(new Exception());
            controller = new ProductsController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(product.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
