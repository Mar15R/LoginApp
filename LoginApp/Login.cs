using LoginApp.Forum;
using LoginApp.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SecurityService securityService = new SecurityService();
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var result = securityService.ValidateUser(username, password);
                if (result.IsSuccess)
                {
                    switch (result.Data.UserRole)
                    {
                        case "Admin":
                            {
                                AdminMain adminMain = new AdminMain(result.Data);
                                adminMain.Show();
                                break;
                            }
                        case "User":
                            {
                                UserMain userMain = new UserMain(result.Data);
                                userMain.Show();
                                break;
                            }
                    }

                    this.Hide();
                }
                else
                {
                    lbl_Error.Text = result.ErrorMessage;
                }
            }
            else
            {
                lbl_Error.Text = "Please enter both username and password.";
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            using (var form = new UserRegistration())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.Text = "User registered successfully. Please log in.";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_Username.Text = "Admin";
            txt_Password.Text = "Pass123";
        }
    }
}
