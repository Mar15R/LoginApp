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
using static LoginApp.Lib.Enums;

namespace LoginApp.Forms
{
    public partial class AdminMain : Form
    {
        private User user;
        private AdminViews adminView;

        public AdminMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        Helper helper = new Helper();
        Factory factory = new Factory();
        private void AdminMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Admin Main - Welcome {user.Name} {user.Surname}";
            helper.ReloadGrid(gv_Data, factory.GetStudentViews(), new List<int> { 0 }, true, true);
            adminView = AdminViews.Students;
        }

        private void AdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Users_Click(object sender, EventArgs e)
        {
            helper.ReloadGrid(gv_Data, factory.GetUserViews(), new List<int> { 0 }, true, true);
            adminView = AdminViews.Users;
        }

        private void gv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = gv_Data.Rows[e.RowIndex].DataBoundItem;


            if (e.ColumnIndex == gv_Data.Columns["btnDelete"].Index)
            {
                switch (selectedRow)
                {
                    case UserView user:
                        {

                            break;
                        }
                    case StudentView student:
                        {
                            break;
                        }
                }
            }
            else if (e.ColumnIndex == gv_Data.Columns["btnUpdate"].Index)
            {
                switch (selectedRow)
                {
                    case UserView user:
                        {
                            UserUpdate userUpdate = new UserUpdate(user);
                            userUpdate.FormClosed+= (s, args) => helper.ReloadGrid(gv_Data, factory.GetUserViews(), new List<int> { 0 }, true, true);
                            userUpdate.ShowDialog();
                            break;
                        }
                    case StudentView student:
                        {
                            break;
                        }
                }
            }
        }
    }
}
