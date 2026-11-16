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

namespace LoginApp.Forms
{
    public partial class UserMain : Form
    {
        private User user;
        public UserMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        Helper helper = new Helper();
        Factory factory = new Factory();

        private void UserMain_Load(object sender, EventArgs e)
        {
            this.Text = $"User Main - Welcome {user.Name} {user.Surname}";
            helper.ReloadGrid(gv_Data, factory.GetStudentViews(), new List<int> { 0 }, false);
        }

        private void UserMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
