using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Views;

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
        public List<UserView> GetUserViews()
        {
            try
            {
                List<User> users = repo.GetEntities<User>();
                if (users != null)
                {
                    return users.Select(u => new UserView
                    {
                        UserName = u.UserName,
                        Name = u.Name,
                        Surname = u.Surname,
                        Password = u.Password,
                        Enabled = u.Enabled,
                        DisableUntil = u.DisableUntil,
                        UserRole = u.UserRole
                    }).ToList();
                }
            }
            catch { throw; }
            return null;
        }
        public Result<bool> CheckIfUsernameExists(string username)
        {
            try
            {
                User user = repo.GetEntityByFilter<User>(u => u.UserName == username);
                if (user != null)
                {
                    return new Result<bool> { Data = true };
                }
                else
                {
                    return new Result<bool> { Data = false };
                }
            }
            catch (Exception ex)
            {
                return new Result<bool> { ErrorMessage = ex.Message };
            }
        }
        public Result<bool> UpdateUser(UserView userview)
        {
            try
            {
                var entity = repo.GetEntityById<User>(userview.UserName);
                if (entity == null)
                {
                    return new Result<bool> { ErrorMessage = "User not found." };
                }
                else
                {
                    entity.Name = userview.Name;
                    entity.Surname = userview.Surname;
                    entity.Password = userview.Password;
                    entity.Enabled = userview.Enabled;
                    entity.DisableUntil = userview.DisableUntil;
                    entity.UserRole = userview.UserRole;
                }
                return new Result<bool> { Data = repo.UpdateEntity<User>(entity) };
            }
            catch(Exception ex)
            {
                return new Result<bool> { ErrorMessage = ex.Message };
            }
        }
        public Result<List<UserRoles>> GetUserRoles()
        {
            try
            {
                List<UserRoles> userRoles = repo.GetEntities<UserRoles>();
                if (userRoles != null)
                {
                    return new Result<List<UserRoles>> { Data = userRoles };
                }
            }
            catch (Exception ex)
            {
                return new Result<List<UserRoles>> { ErrorMessage = ex.Message };
            }
            return new Result<List<UserRoles>> { ErrorMessage = "No user roles found." };
        }
    }
}
