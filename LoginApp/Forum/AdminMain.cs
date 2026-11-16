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
    public partial class AdminMain : Form
    {
        Factory factory = new Factory();
        private User user;

        public AdminMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        Helper helper = new Helper();
        private void AdminMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Admin Main - Welcome {user.Name} {user.Surname} :)";
            helper.ReloadGrid(gv_Data, factory.GetStudentViews(), new List<int> { 0 }, true, true);
        }

        private void AdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
