﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using P2FixAnAppDotNetCode.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application
            //DONE
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            Product product = GetAllProducts().Find(p=>p.Id == id);
            Console.WriteLine(product);
             return product  ;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            foreach (var item in cart.Lines)
            {
                _productRepository.UpdateProductStocks(item.Product.Id, item.Quantity);
            }
            
        }
    }
}
