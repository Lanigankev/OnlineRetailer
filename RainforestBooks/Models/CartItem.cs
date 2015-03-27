using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class CartItem: IEquatable<CartItem> {

        public CartItem() 
        { }
    // A place to store the quantity in the cart
    // This property has an implicit getter and setter.
    public int Quantity { get; set; }
 
    private int _productId;
    public int ProductId {
        get { return _productId; }
        set {
            // To ensure that the Prod object will be re-created
            _product = null;
            _productId = value;
        }
    }
 
    private Product _product = null;
    
        public Product Prod {
        get {
            // Lazy initialization - the object won't be created until it is needed
            if (_product == null) {
                _product = PopulateProduct(ProductId);
            }
            return _product;
        }
    }
 
    public string Title {
        get { return Prod.ProductTitle; }
    }
 
    public decimal UnitPrice {
        get { return Prod.Cost; }
    }
 
    public decimal TotalPrice {
        get { return UnitPrice * Quantity; }
    }
 
    // CartItem constructor just needs a productId
    public CartItem(int productId) {
        this.ProductId = productId;
    }
 
    /**
     * Equals() - Needed to implement the IEquatable interface
     *    Tests whether or not this item is equal to the parameter
     *    This method is called by the Contains() method in the List class
     *    We used this Contains() method in the ShoppingCart AddItem() method
     */
    public bool Equals(CartItem item) {
        return item.ProductId == this.ProductId;
    }

        //A method to get a populated product from the database
    private Product PopulateProduct(int productId)
    {
        Product populatedProduct;
        try
        {
            using (var db = new Context())
            {
                populatedProduct = (from p in db.Products where p.ProductId == productId select p).FirstOrDefault();

            }
            return populatedProduct;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
    public override string ToString()
    {
        return string.Format("{0} \t{1} \t{2} \t{3}", this.Title, this.Quantity, this.UnitPrice, this.TotalPrice);
    }
    }

    
}