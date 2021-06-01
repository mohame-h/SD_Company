using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Services
{
    public class DepartmentService : IGeneric<Department>
    {
        private SD_CompanyContext db;

        public DepartmentService(SD_CompanyContext db)
        {
            this.db = db;
        }

     
        List<Department> IGeneric<Department>.RetriveAll()
        {
            try
            {
                var departments = db.Departments.ToList();
                if (departments.Count==0)
                {
                    return null;
                }

                return departments;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        Department IGeneric<Department>.Retrive(int id)
        {
            try
            {
                var department = db.Departments.Find(id);
                if (department == null)
                {
                    return null;
                }

                return department;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Department Create(Department item)
        {
            try
            {
                db.Departments.Add(item);

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

        bool IGeneric<Department>.Delete(int id)
        {
            try
            {
                var department = db.Departments.Find(id);
                db.Departments.Remove(department);

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

        Department IGeneric<Department>.Put(Department item)
        {
            try
            {
                db.Departments.Update(item);

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


    }
}
