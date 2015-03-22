using RainforestBooks.Functions;
using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductTitle = txtName.Text;
            product.ProductImageRef = txtImage.Text;
            product.InStock = int.Parse(txtAmount.Text);
            product.Cost = decimal.Parse(txtCost.Text);
            product.ProductDescription = txtDescription.Text;
            product.Category = txtCategory.Text;
            product.Genre = txtGenre.Text;
            


            var db = new Context();
            db.Products.Add(product);
            db.SaveChanges();
            
            ClearForm();

        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtImage.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCost.Text = string.Empty;
           txtDescription.Text = string.Empty;
           txtCategory.Text = string.Empty;
           txtGenre.Text = string.Empty;
        }
        }
    }