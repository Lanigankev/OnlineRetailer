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

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (AdminSession.IsAdminSession() != true)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddItem();
            Response.Write("<script language='javascript'>alert('Item added');</script>");
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

       private void GetProductType()
        {
           if (RadioButton1.Checked)
           {
               type = "Book";
               lblCatergory.Visible = false;
           }
           else if (RadioButton2.Checked)
           {
               type = "Book Accessory";
               cmbGenre.Text = "NA";
               lblCatergory.Visible = false;
           }
           else if (!RadioButton1.Checked && !RadioButton2.Checked)
           {
               lblCatergory.Visible = true;
           }
        }

        private void AddItem()
        {
            GetProductType();
            var _db = new Context();
            Validation val = new Validation();

          
            
            bool emptyTitle = true;
            bool emptyDescription = true;
            bool wrongStock = true;
            bool emptyStock = true;
            bool emptyCost = true;
            bool wrongCost = true;
            bool productExists = _db.Products.Any(product => product.ProductTitle == txtName.Text);
            emptyTitle = string.IsNullOrEmpty(txtName.Text);
            emptyDescription = string.IsNullOrEmpty(txtDescription.Text);
            emptyStock = string.IsNullOrEmpty(txtStock.Text);
            wrongStock = val.NumberValidator(txtStock.Text) == null ? false : true;
            emptyCost = string.IsNullOrEmpty(txtCost.Text);
            wrongCost = val.DecimalValidator(txtCost.Text) == null ? false : true;

            if (emptyTitle)
            {
                lblProduct.Text = "** No name entered";
                lblProduct.Visible = true;
            }
            else if (productExists)
            {
                lblProduct.Text = "** This book already exists";
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

            if (wrongStock)
            {
                lblStock.Text = val.NumberValidator(txtStock.Text);
                lblStock.Visible = true;
            }
            else if (emptyStock)
            {
                lblStock.Visible = true;
            }
            else
            {
                lblStock.Visible = false;
            }
            if (wrongCost)
            {
                lblCost.Text = val.DecimalValidator(txtCost.Text);
                lblCost.Visible = true;
            }
            else if (emptyCost)
            {
                lblCost.Visible = true;
            }
            else
            {
                lblCost.Visible = false;
            }

            if (!emptyTitle && !emptyDescription && !emptyCost && !emptyStock && RadioButton1.Checked || RadioButton2.Checked)
            {
                if (txtImageUpload.HasFile)
                {
                    string fileName = (Guid.NewGuid().ToString() + "-" + txtImageUpload.FileName);

                    txtImageUpload.SaveAs(Server.MapPath("~/Content/BookCovers/" + fileName));
                    HyperLink1.Text = fileName;
                    //HyperLink1.NavigateUrl = Request.MapPath("Content/BookCovers/") + txtImageUpload.FileName;
                }
                Product product = new Product();
                product.ProductTitle = txtName.Text;
                product.InStock = int.Parse(txtStock.Text);
                product.Cost = decimal.Parse(txtCost.Text);
                product.ProductDescription = txtDescription.Text;
                product.Genre = cmbGenre.Text;
                product.Category = type;
                product.ProductImageRef = HyperLink1.Text;

                _db.Products.Add(product);
                _db.SaveChanges();

                ClearForm();
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            cmbGenre.Enabled = true;
            lblCatergory.Visible = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
            cmbGenre.Enabled = false;
            lblCatergory.Visible = false;
        }
        }
        }
   