using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Services
{
    public class LoginService : ILogin<Login>
    {
        private SD_CompanyContext db;

        public LoginService(SD_CompanyContext db)
        {
            this.db = db;
        }

     
        List<Login> ILogin<Login>.RetriveAll()
        {
            try
            {
                var logins = db.Logins.ToList();
                if (logins.Count==0)
                {
                    return null;
                }

                return logins;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        Login ILogin<Login>.Retrive(string email)
        {
            try
            {
                var login = db.Logins.FirstOrDefault(x=> x.Email == email);
                if (login == null)
                {
                    return null;
                }

                return login;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Login Create(Login item)
        {
            try
            {
                db.Logins.Add(item);

                var affected = db.SaveChanges();
                if (affected == 0)
                {
                    return null;
                }

                return item;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        bool ILogin<Login>.Delete(string email)
        {
            try
            {
                var login = db.Logins.FirstOrDefault(x => x.Email == email);
                db.Logins.Remove(login);

                int affected = db.SaveChanges();
                if (affected == 0)
                {
                    return false;
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        Login ILogin<Login>.Put(Login item)
        {
            try
            {
                var login = db.Logins.FirstOrDefault(x => x.Email == item.Email);
                login.Password = item.Password;

                var affected = db.SaveChanges();
                if (affected == 0)
                {
                    return null;
                }

                return login;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


    }
}
