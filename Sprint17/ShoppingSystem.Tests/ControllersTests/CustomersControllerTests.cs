using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ShoppingSystem.Services;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using System.Threading.Tasks;
using FluentAssertions;
using System;
using Microsoft.EntityFrameworkCore;

namespace ShoppingSystem.Tests.ControllersTests
{
    public class CustomersControllerTests
    {
        Mock<ICustomers> mock = new Mock<ICustomers>();
        CustomersController controller;

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfCustomers()
        {
            SortState sortOrder = default;
            string searchString = null;
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetCustomers());
            controller = new CustomersController(mock.Object);

            var result = await controller.Index(searchString, sortOrder);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Customer>>(viewResult.Model);
            Assert.Equal(GetCustomers().Count, model.Count());
        }

        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Ramil", LastName = "Naum", Address = "Los-Ang", Discount = "5"},
                new Customer {Id = 2, FirstName = "Bob", LastName = "Dillan", Address = "Berlin", Discount = "7"},
                new Customer {Id = 3, FirstName = "Kile", LastName = "Rise", Address = "London", Discount = "0"},
                new Customer {Id = 4, FirstName = "John", LastName = "Konor", Address = "Vashington", Discount = "3"}
            };

            return customers;
        }

        [Fact]
        public async Task Details_Returns_ViewResult_CustomerByID()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(customer);
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
            customer.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async Task Details_Returns_BadRequestResult()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(id)).Throws(new Exception());
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Details(id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        //POST
        [Fact]
        public async Task Create_CustomerReturns_RedirectToActionResult()
        {
            controller = new CustomersController(mock.Object);
            Customer newCustomer = new Customer
            {
                FirstName = "Ramil",
                LastName = "Naum",
                Address = "Los-Ang",
                Discount = "5"
            };


            var result = await controller.Create(newCustomer);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.AddAsync(newCustomer));
        }

        [Fact]
        public async Task Create_CustomerReturnsViewResultWithCustomerModel()
        {
            controller = new CustomersController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            Customer newCustomer = new Customer();

            var result = await controller.Create(newCustomer);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(newCustomer, viewResult?.Model);

        }

        //GET
        [Fact]
        public async Task Edit_Returns_CustomerInfoForEditing()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock
                .Setup(repo => repo.GetByIdAsync(customer.Id)).ReturnsAsync(customer);
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Edit(customer.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        

        //POST
        [Fact]
        public async Task EditPOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(customer));
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Edit(id, customer);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.EditAsync(customer));
        }

        //POST
        [Fact]
        public async Task EditPOST_Returns_BadRequestResult()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.EditAsync(customer))
                .ThrowsAsync(new DbUpdateConcurrencyException());
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Edit(id, customer);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);

        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <returns></returns>
        /// 

        //GET
        [Fact]
        public async Task Delete_Returns_WhenCustomerIsNotFound()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);
            //Arrange
            mock.Setup(repo => repo.DeleteAsync(customer.Id));
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Delete(customer.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<NotFoundResult>(result);
        }

        //GET
        [Fact]
        public async Task Delete_Returns_CustomerInfoForDeleting()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.GetByIdAsync(customer.Id)).ReturnsAsync(customer);
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.Delete(customer.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //POST
        [Fact]
        public async Task DeletePOST_Returns_RedirectToActionResult()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(customer.Id));
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(customer.Id);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.DeleteAsync(customer.Id));
        }
        //POST
        [Fact]
        public async Task DeletePOST_Returns_CustomerInfoForDeleting()
        {
            int id = 4;
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

            //Arrange
            mock.Setup(repo => repo.DeleteAsync(customer.Id)).Throws(new Exception());
            controller = new CustomersController(mock.Object);

            //Act
            var result = await controller.DeleteConfirmed(customer.Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public async Task GetCustomer_ReturnsBadRequestResult_WhenIdIsNull()
        //{
        //    // Arrange           
        //    controller = new CustomersController(mock.Object);
        //    // Act
        //    var result = await controller.Edit(null);
        //    var result = await controller.Delete(null);

        //    // Arrange
        //    Assert.IsType<BadRequestResult>(result);
        //}

        //[Fact]
        //public async Task GetCustomerReturnsNotFoundResultWhenCustomerNotFound()
        //{
        //    // Arrange
        //    int id = 4;
        //    var customer = GetCustomers().FirstOrDefault(p => p.Id == id);

        //    mock.Setup(repo => repo.EditAsync(customer))
        //        .Returns(null as Customer);
        //    controller = new CustomersController(mock.Object);

        //    // Act
        //    var result = await controller.Edit(id, customer);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}
    }
}
