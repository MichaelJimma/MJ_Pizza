using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJ_Pizza
{
    public partial class ContactForm : Form
    {
        PizzaForm frmPizza;
        string name;
        string phone;
        string email;
        string address;
        IList<string> lstContactInfo = new List<string>();
        public ContactForm(PizzaForm frm)
        {
            InitializeComponent();
            frmPizza = frm;
        }

        public static bool IsEmpty(string value)//return true if the value passed is empty
        {
            return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if(!IsEmpty(txtName.Text.ToString()))
                if(!IsEmpty(txtPhone.Text.ToString()))
                    if(!IsEmpty(txtAddress.Text.ToString()))
                        {
                            name = txtName.Text.ToString();
                            phone = txtPhone.Text.ToString();
                            email = txtEmail.Text.ToString();
                            address = txtAddress.Text.ToString();
                            lstContactInfo.Add(string.Format("Name: {0}",name));
                            lstContactInfo.Add(string.Format("Phone: {0}", phone));
                            lstContactInfo.Add(string.Format("Email: {0}", email));
                            lstContactInfo.Add(string.Format("Address: {0}", address));
                            frmPizza.lstContact = this.lstContactInfo;
                            this.Close();
                        }
                        else
                        {
                            errorProvider1.SetError(txtAddress, "You must provide address.");
                            txtAddress.Focus();
                        }
                    else
                    {
                        errorProvider1.SetError(txtPhone, "You must provide phone number.");
                        txtPhone.Focus();
                    }
                else
                {
                    errorProvider1.SetError(txtName, "You must provide name.");
                    txtName.Focus();
                }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!IsEmpty(txtName.Text))
                errorProvider1.SetError(txtName, string.Empty);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!IsEmpty(txtPhone.Text))
                errorProvider1.SetError(txtPhone, string.Empty);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!IsEmpty(txtAddress.Text))
                errorProvider1.SetError(txtAddress, string.Empty);
        }
    }
}
