using System;
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
        /// Read_only for Display
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        public List<CartLine> GetCartLineList()
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

                var existing = FindProductInCartLines(product.Id);
                CartLine newCartLine;
                if (existing == null || GetCartLineList().Count() == 0)
                {
                    newCartLine = new CartLine(GetCartLineList().Count() + 1, product, quantity);
                    GetCartLineList().Add(newCartLine);

                }
                else
                {
                    newCartLine = GetCartLineList().Where(l => l.Product == product).FirstOrDefault();
                    newCartLine.Quantity += quantity;

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
            var existing = GetCartLineList().Where(l => l.Product.Id == productId).FirstOrDefault();
            if(existing == null) {  return null; } else { return existing.Product; }

        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToList()[index];
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
