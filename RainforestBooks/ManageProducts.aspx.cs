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
        public string type { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
           

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "Book";
            //rdoAccessory.Checked = false;
            //cmbGenre.Enabled = true;
            cmbGenre.Visible = true;
        }

        protected void rdoAccessory_CheckedChanged(object sender, EventArgs e)
        {
            type = "Accessory";
            //rdoBook.Checked = false;
            //cmbGenre.Enabled = false;
            cmbGenre.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             

            Product product = new Product();
            product.ProductTitle = txtName.Text;
            product.ProductImageRef = HyperLink1.Text;
            product.InStock = int.Parse(txtStock.Text);
            product.Cost = decimal.Parse(txtCost.Text);
            product.ProductDescription = txtDescription.Text;
            product.Category = "x";
            product.Genre = cmbGenre.Text;
            


            var db = new Context();
            db.Products.Add(product);
            db.SaveChanges();
            
            ClearForm();

        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbGenre.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtImageUpload.HasFile)
            {
                string fileName = (Guid.NewGuid().ToString() + "-" + txtImageUpload.FileName);
                
                txtImageUpload.SaveAs(Server.MapPath("~/Content/BookCovers/" + fileName));
                HyperLink1.Text = fileName;
                //HyperLink1.NavigateUrl = Request.MapPath("Content/BookCovers/") + txtImageUpload.FileName;
            }
        }
        }
        }
   