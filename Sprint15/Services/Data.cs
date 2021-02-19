using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsValidation.Models;

namespace ProductsValidation.Services
{
    public class Data
    {
        public List<Product> Products = new List<Product>
        {
            new Product() {Id = 1, Type = Product.Category.Toy, Name = "Bear", Description = "Bear Description", Price = 48},
            new Product() {Id = 2, Type = Product.Category.Clothes, Name = "Dress", Description = "Dress Description", Price = 300},
            new Product() {Id = 3, Type = Product.Category.Transport, Name = "Tesla Model 3", Description = "Tesla Model 3 Description", Price = 65000},
            new Product() {Id = 4, Type = Product.Category.Toy, Name = "Pistol", Description = "Pistol Description", Price = 25},
            new Product() {Id = 5, Type = Product.Category.Technique, Name = "Iphone 12 Pro Max", Description = "Iphone 12 Pro Max Description", Price = 1100},
            new Product() {Id = 6, Type = Product.Category.Transport, Name = "Bus", Description = "Bus Description", Price = 32050},
            new Product() {Id = 7, Type = Product.Category.Clothes, Name = "Pants", Description = "Pants Description", Price = 40},
            new Product() {Id = 8, Type = Product.Category.Technique, Name = "Galaxy Note 20 Ultra", Description = "Galaxy Note 20 Ultra Description", Price = 1300},
            new Product() {Id = 9, Type = Product.Category.Transport, Name = "Yamaha R1", Description = "Yamaha R1 Description", Price = 20000},
            new Product() {Id = 11, Type = Product.Category.Transport, Name = "Helicopter", Description = "Helicopter Description", Price = 40000},
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 0, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 0, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 0, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 0, Name = "User2", Email = "user2@gmail.com", Role = "user"}
        };
    }
}
