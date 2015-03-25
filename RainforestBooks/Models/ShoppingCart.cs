using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class ShoppingCart
    {//this used to be private set
        public List<CartItem> CartItems { get; set; }

        // Readonly properties can only be set in initialization or in a constructor
        public static readonly ShoppingCart Instance;

        // The static constructor is called as soon as the class is loaded into memory
        static ShoppingCart()
        {
            // If the cart is not in the session, create one and put it there
            // Otherwise, get it from the session
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                Instance = new ShoppingCart();
                Instance.CartItems = new List<CartItem>();
                HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session["ASPNETShoppingCart"];
            }
        }

        public ShoppingCart() 
        { }

        public void AddItem(int productId)
        {
            // Create a new item to add to the cart
            CartItem newItem = new CartItem(productId);
                    
            
            // If this item already exists in our list of items, increase the quantity
            // Otherwise, add the new item to the list
            if (CartItems.Contains(newItem))
            {
                foreach (CartItem item in CartItems)
                {
                    if (item.Equals(newItem))
                    {
                        
                        item.Quantity++;
                        return;
                            
                        
                        
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                CartItems.Add(newItem);
            }
        }

        public void SetItemQuantity(int productId, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in CartItems)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        /**
     * RemoveItem() - Removes an item from the shopping cart
     */
    public void RemoveItem(int productId) {
        CartItem removedItem = new CartItem(productId);
        CartItems.Remove(removedItem);
    }
    
    /**
     * GetSubTotal() - returns the total price of all of the items
     *                 before tax, shipping, etc.
     */
    public decimal GetSubTotal() {
        decimal subTotal = 0;
        foreach (CartItem item in CartItems)
            subTotal += item.TotalPrice;
 
        return subTotal;
    }

    }
}