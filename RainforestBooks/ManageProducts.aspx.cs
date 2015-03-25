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
            AddItem();
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

        private void AddItem()
        {
            var _db = new Context();
            Validation val = new Validation();

            bool emptyTitle = true;
            bool emptyDescription = true;
            bool emptyImage = true;
            bool emptyStock = true;
            bool emptyCost = true;
            bool productExists = _db.Products.Any(product => product.ProductTitle == txtName.Text);

            emptyTitle = string.IsNullOrEmpty(txtName.Text);
            emptyDescription = string.IsNullOrEmpty(txtDescription.Text);
            emptyImage = string.IsNullOrEmpty(HyperLink1.Text);
            emptyStock = string.IsNullOrEmpty(txtStock.Text);
            emptyStock = val.NumberValidator(txtStock.Text) == null ? false : true;
            emptyCost = string.IsNullOrEmpty(txtCost.Text);
            emptyCost = val.NumberValidator(txtCost.Text) == null ? false : true;

            if (emptyTitle)
            {
                lblProduct.Text = "** No name entered";
                lblProduct.Visible = true;
            }
            else if (productExists)
            {
                lblProduct.Text = "** Product already exists";
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
            if (emptyImage)
            {
                lblImage.Visible = true;
            }
            else
            {
                lblImage.Visible = false;
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
            if (!emptyTitle && !productExists && !emptyDescription && !emptyImage && !emptyCost && !emptyStock)
            {
                Product product = new Product();
                product.ProductTitle = txtName.Text;
                product.ProductImageRef = HyperLink1.Text;
                product.InStock = int.Parse(txtStock.Text);
                product.Cost = decimal.Parse(txtCost.Text);
                product.ProductDescription = txtDescription.Text;
                product.Category = type;
                product.Genre = cmbGenre.Text;




                _db.Products.Add(product);
                _db.SaveChanges();

                ClearForm();
            }
        }
        }
        }
   