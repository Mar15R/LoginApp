using LoginApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Lib
{
    public class Factory
    {
       Repository repo = new Repository(new UniversityEntities());
        public List<StudentView> GetStudentViews()
        {
            try
            {
                List<Student> students = repo.GetEntities<Student>(100);
                if (students != null)
                {
                    return students.Select(s => new StudentView
                    {
                        Id_Student = s.Id_Student,
                        Name = s.Name,
                        Surname = s.Surname,
                        Gender = s.Gender,
                        BirthYear = s.BirthYear,
                        Scholarship = s.Scholarship,
                        CourseName = s.Course != null ? s.Course.Name : null
                    }).ToList();
                }
            }
            catch { throw; }
            return null;
        }
    }
}
