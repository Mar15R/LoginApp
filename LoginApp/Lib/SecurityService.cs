using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp.Lib
{
    public class SecurityService
    {
        Repository repo = new Repository(new UniversityEntities());
        public Result<User> ValidateUser(string username, string password)
        {
            try
            {
                User user = repo.GetEntityByFilter<User>(u => u.UserName == username);
                Result<User> result;
                if (user != null)
                {
                    if (VerifyPassword(password, user.Password))
                    {
                        if (user.Enabled || DateTime.Now>user.DisableUntil)
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
            catch (Exception ew)
            {
                return new Result<User> { ErrorMessage = ew.Message };
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
                if (result == false)
                {
                    // check if there are 3 failed attempts in a row for the same user
                    var failedAttempts = repo.GetEntitiesByFilter<Audit>(a => a.UserName == username)
                        .OrderByDescending(a => a.LogTime)
                        .Take(3)
                        .ToList();
                    failedAttempts = failedAttempts.Where(a => a.LogResult == false).ToList();
                    //Disable the user if there are 3 failed attempts in a row
                    if (failedAttempts.Count == 3)
                    {
                        SwitchAccountStatus(username, false);
                    }
                }
                else
                {
                    SwitchAccountStatus(username, true);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }

        }
        private void SwitchAccountStatus(string username, bool enable)
        {
            try
            {
                User user = GetUser(username);
                if (user == null)
                {
                    return;
                }
                user.Enabled = enable;
                user.DisableUntil = enable ? (DateTime?)null : DateTime.Now.AddMinutes(5);
                repo.UpdateEntity<User>(user);
            }
            catch (Exception ex)
            {

            }
        }
        private User GetUser(string username)
        {
            return repo.GetEntityByFilter<User>(u => u.UserName == username);
        }
        public string GetMd5Hash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        public bool VerifyPassword(string password, string storedHash)
        {
            string hash = GetMd5Hash(password);

            return string.Equals(
                hash,
                storedHash,
                StringComparison.OrdinalIgnoreCase
            );
        }
        public Result<bool> CheckPassStrength(string password)
        {
            try
            {
                string specialCharacters = "!@#$%^&*()-_=+.";
                string pattern = BuildPasswordPattern(specialCharacters);


                bool isStrong = Regex.IsMatch(password, pattern);
                if (isStrong)
                {
                    return new Result<bool> { Data = isStrong };
                }
                else
                {
                    return new Result<bool> { ErrorMessage = $"Password does not meet strength requirements (8 characters, including uppercase, " +
                        $"lowercase, number, and special character - {specialCharacters})." };
                }
            }
            catch (Exception ex)
            {
                return new Result<bool> { ErrorMessage = ex.Message };
            }
        }
        public string BuildPasswordPattern(string specialCharacters)
        {
            string escapedSpecial = Regex.Escape(specialCharacters);

            return $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[{escapedSpecial}])[A-Za-z\d{escapedSpecial}]{{8,}}$";
        }
        public Result<bool> RegisterNewUser(User newUser)
        {
            try
            {
                newUser.Password = GetMd5Hash(newUser.Password);
                newUser.Enabled = true;
                newUser.UserRole = "User";
                repo.InsertEntity<User>(newUser);
                return new Result<bool> { Data = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { ErrorMessage = ex.Message };
            }
        }
        public string GeneratePassword(int length = 8)
        {
            Random rnd = new Random();
            bool isStrong = false;
            string passwordStr = "";
            while (!isStrong)
            {
                const string chars =
                "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789" +
                "!@#$%^&*()-_=+.";

                char[] password = new char[length];

                for (int i = 0; i < length; i++)
                {
                    int index = rnd.Next(chars.Length);
                    password[i] = chars[index];
                }
                passwordStr = new string(password);
                isStrong = CheckPassStrength(passwordStr).Data;
            }

            return passwordStr;
        }
    }
}
