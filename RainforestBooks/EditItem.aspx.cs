using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class EditItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ItemEdit()
        {
            var _db = new Context();
            Validation val = new Validation();

            bool emptyTitle = true;
            bool emptyDescription = true;
            bool emptyStock = true;
            bool emptyCost = true;


            emptyTitle = string.IsNullOrEmpty(txtName.Text);
            emptyDescription = string.IsNullOrEmpty(txtDescription.Text);
            emptyStock = string.IsNullOrEmpty(txtStock.Text);
            emptyStock = val.NumberValidator(txtStock.Text) == null ? false : true;
            emptyCost = string.IsNullOrEmpty(txtCost.Text);
            emptyCost = val.DecimalValidator(txtCost.Text) == null ? false : true;

            if (emptyTitle)
            {
                lblProduct.Text = "** No name entered";
                lblProduct.Visible = true;
            }
            else
            {
                lblProduct.Visible = false;
            }
            if (emptyDescription)
            {
                lblDescription.Visible = true;
            }
            else
            {
                lblDescription.Visible = false;
            }

            if (emptyStock)
            {
                lblStock.Text = val.NumberValidator(txtStock.Text);
                lblStock.Visible = true;
            }
            else
            {
                lblStock.Visible = false;
            }
            if (emptyCost)
            {
                lblCost.Visible = true;
            }
            else
            {
                lblCost.Visible = false;
            }

            if (!emptyTitle && !emptyDescription && !emptyCost && !emptyStock)
            {
                Product product = (from prod in _db.Products
                                   where prod.ProductTitle == txtName.Text
                                   select prod).First();

                product.ProductTitle = txtName.Text;
                product.InStock = int.Parse(txtStock.Text);
                product.Cost = decimal.Parse(txtCost.Text);
                product.ProductDescription = txtDescription.Text;
                product.Genre = cmbGenre.Text;

                _db.SaveChanges();

                ClearForm();
            }

        }
       private void ClearForm()
           {
            txtName.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            }

       protected void btnSearch_Click(object sender, EventArgs e)
       {
           var _db = new Context();

           Product prod = (from p in _db.Products
                               where p.ProductTitle == txtName.Text
                               select p).First();

           txtDescription.Text = prod.ProductDescription;
           imgItem.ImageUrl = "~/Content/BookCovers/" + prod.ProductImageRef;           
           txtStock.Text = prod.InStock.ToString();
           txtCost.Text = prod.Cost.ToString();
       }

       protected void btnSubmit_Click(object sender, EventArgs e)
       {
           ItemEdit();
       }   
    }
}