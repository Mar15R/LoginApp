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
    public partial class AdminMain : Form
    {
        private User user;
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
            helper.ReloadGrid(gv_Data, factory.GetStudentViews(),new List<int> {0}, true, true);
        }

        private void AdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
