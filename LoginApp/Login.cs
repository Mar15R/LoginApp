using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Forms;
using LoginApp.Lib;

namespace LoginApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SecurityService securityService = new SecurityService();
        private int remainingTimeInSeconds = 0;
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_UserName.Text;
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
                    remainingTimeInSeconds = result.Value1; // Set the remaining time from the result
                    lb_RemainingTime.Text = result.Value1 > 0 ? $"Remaining time: {result.Value1} seconds" : string.Empty;
                    timer.Start();
                    timer.Interval = 1000; // Set the timer interval to 1 second
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
            txt_UserName.Text = "EdgarsB";
            txt_Password.Text = "Pass123!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(remainingTimeInSeconds > 0)
            {
                remainingTimeInSeconds--;
                lb_RemainingTime.Text = $"Remaining time: {remainingTimeInSeconds} seconds";
            }
            else
            {
                remainingTimeInSeconds = 0;
                lb_RemainingTime.Text = string.Empty;
                timer.Stop();
            }
        }
    }
}
