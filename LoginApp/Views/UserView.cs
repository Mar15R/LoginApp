using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Views
{
    public class UserView
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> DisableUntil { get; set; }
        public string UserRole { get; set; }
    }
}
