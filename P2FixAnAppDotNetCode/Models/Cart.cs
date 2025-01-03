﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return new List<CartLine>();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            try
            {
                List<CartLine> cartline = Lines.ToList();
                //foreach (CartLine line in cartline)
                //{
                //    if (line.Product == product)
                //    {
                //        line.Quantity+=quantity;
                //        return;
                //    }
                //}
                var existing = Lines.Where(l => l.Product == product).FirstOrDefault();
                CartLine newCartLine;
                if (existing == null || this.Lines.Count()==0 )
                {
                    newCartLine = new CartLine(Lines.Count() + 1, product, quantity);
                    this.Lines.ToList().Add(newCartLine);
                }
                else { 
                    existing.Quantity += quantity;
                }

            }
            catch
            {
                throw;
            }
        }
            
        
        

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {

        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public CartLine(int orderLineId, Product product, int quantity)
        {
            OrderLineId = orderLineId;
            Product = product;
            Quantity = quantity;
        }
    }
}
