using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Views
{
    public class StudentView
    {
        public long Id_Student { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> BirthYear { get; set; }
        public Nullable<decimal> Scholarship { get; set; }
        public string CourseName { get; set; }
    }
}
