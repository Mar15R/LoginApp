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

namespace LoginApp.Forum
{
    public partial class UserMain : Form
    {
        Factory factory = new Factory();
        Helper helper = new Helper();
        private User user;

        public UserMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            this.Text = $"User Main - Welcome {user.Name} {user.Surname}";
            helper.ReloadGrid(gv_Data, factory.GetStudentViews(), new List<int> { 0 }, false);
        }

        private void UserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
