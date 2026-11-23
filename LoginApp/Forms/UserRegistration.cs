using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Lib;

namespace LoginApp.Forms
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }
        SecurityService securityService = new SecurityService();
        Factory factory = new Factory();
        private void txt_Password_Leave(object sender, EventArgs e)
        {
            var result = securityService.CheckPassStrength(txt_Password.Text);
            if (!result.Data)
            {
                lb_Error.Text = result.ErrorMessage;
            }
            else
            {
                lb_Error.Text = "";
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Username.Text)
                    && !string.IsNullOrEmpty(txt_Name.Text)
                    && !string.IsNullOrEmpty(txt_Surname.Text)
                    && !string.IsNullOrEmpty(txt_Password.Text)
                    && !string.IsNullOrEmpty(txt_RepPassword.Text))
                {
                    if (txt_Password.Text != txt_RepPassword.Text)
                    {
                        lb_Error.Text = "Passwords do not match.";
                        return;
                    }
                    User user = new User
                    {
                        UserName = txt_Username.Text,
                        Name = txt_Name.Text,
                        Surname = txt_Surname.Text,
                        Password = txt_Password.Text
                    };
                    var result = securityService.RegisterNewUser(user);
                    if (result.IsSuccess)
                    {
                        lb_Error.Text = "User registered successfully.";
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        lb_Error.Text = result.ErrorMessage;
                    }
                }
                else
                {
                    lb_Error.Text = "Please fill in all fields.";
                }
            }
            catch (Exception ex) { lb_Error.Text = ex.Message; }
        }

        private void txt_Username_Leave(object sender, EventArgs e)
        {
            var result = factory.CheckIfUsernameExists(txt_Username.Text);
            if (result.Data)
            {
                lb_Error.Text = "Username already exists.";
            }
            else
            {
                lb_Error.Text = "";
            }
        }

        private void txt_Name_Leave(object sender, EventArgs e)
        {
            txt_Name.Text = NormalizeString(txt_Name.Text);
        }
        private void txt_Surname_Leave(object sender, EventArgs e)
        {
            txt_Surname.Text = NormalizeString(txt_Surname.Text);
        }
        private string NormalizeString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            string normalized = input.ToLower();
            normalized = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes(normalized));
            normalized = char.ToUpper(normalized[0]) + normalized.Substring(1);
            return normalized;
        }
    }
}
