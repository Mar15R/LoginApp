using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Lib
{
    public class SecurityService
    {
        Repository repo = new Repository(new UniversityEntities());
        public Result<User> ValidateUser(string username, string password)
        {
            try
            {
                User user = repo.GetEntityById<User>(username);
                Result<User> result;
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        if (user.Enabled)
                        {
                            result = new Result<User> { Data = user };
                        }
                        else
                        {
                            result = new Result<User> { ErrorMessage = "User is not enabled." };
                        }
                    }
                    else
                    {
                        result = new Result<User> { ErrorMessage = "Invalid password." };
                    }
                }
                else
                {
                    result = new Result<User> { ErrorMessage = "Such user does not exist." };
                }
                AuditLogin(username, result.IsSuccess);
                return result;
            }
            catch (Exception ex)
            {
               return new Result<User> { ErrorMessage = ex.Message };
            }
        }
        private void AuditLogin(string username, bool result)
        {
            try
            {
                Audit log = new Audit
                {
                    UserName = username,
                    LogTime = DateTime.Now,
                    LogResult = result
                };
                repo.InsertEntity<Audit>(log);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
    }
}
