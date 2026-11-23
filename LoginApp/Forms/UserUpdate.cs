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
using LoginApp.Views;

namespace LoginApp.Forms
{
    public partial class UserUpdate : Form
    {
        private UserView user;
        public UserUpdate(UserView user)
        {
            InitializeComponent();
            this.user = user;
        }
        Factory factory = new Factory();
        SecurityService securityService = new SecurityService();
        private void btn_Update_Click(object sender, EventArgs e)
        {
            var result = factory.UpdateUser(new UserView
            {
                UserName = user.UserName,
                Name = txt_Name.Text,
                Surname = txt_Surname.Text,
                Password = string.IsNullOrEmpty(txt_Password.Text) ? user.Password : securityService.GetMd5Hash(txt_Password.Text),
                Enabled = ckb_Enabled.Checked,
                DisableUntil = user.DisableUntil,
                UserRole = cb_Roles.SelectedValue?.ToString()
            });
            if (result.IsSuccess && result.Data == true)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lb_Error.Text = result.ErrorMessage;
            }

        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            List<UserRoles> userRoles = factory.GetUserRoles().Data;
            cb_Roles.DataSource = userRoles;
            cb_Roles.DisplayMember = "Description";
            cb_Roles.ValueMember = "UserRole";

            txt_Name.Text = user.Name;
            txt_Surname.Text = user.Surname;
            ckb_Enabled.Checked = user.Enabled;
            cb_Roles.SelectedValue = user.UserRole;
            lb_Username.Text = user.UserName;
        }

        private void btn_GetRndPwd_Click(object sender, EventArgs e)
        {
            txt_Password.Text = securityService.GeneratePassword(8);
        }
    }
}
