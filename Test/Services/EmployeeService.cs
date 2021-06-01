using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Services
{
    public class EmployeeService : IGeneric<Employee>
    {
        private SD_CompanyContext db;

        public EmployeeService(SD_CompanyContext db)
        {
            this.db = db;
        }

     
        List<Employee> IGeneric<Employee>.RetriveAll()
        {
            try
            {
                var employees = db.Employees.ToList();
                if (employees.Count==0)
                {
                    return null;
                }

                return employees;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        Employee IGeneric<Employee>.Retrive(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                if (employee== null)
                {
                    return null;
                }

                return employee;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public Employee Create(Employee item)
        {
            try
            {
                var dept = db.Departments.Find(item.DeptNo);
                if (dept == null)
                {
                    return null;
                }

                db.Employees.Add(item);

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

        bool IGeneric<Employee>.Delete(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                db.Employees.Remove(employee);

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

        Employee IGeneric<Employee>.Put(Employee item)
        {
            try
            {
                var dept = db.Departments.Find(item.DeptNo);
                if (dept == null)
                {
                    return null;
                }

                //var employee= db.Employees.Find(item.EmpNo);

                //employee.Fname = item.Fname;
                //employee.Lname = item.Lname;
                //employee.Salary = item.Salary;
                //employee.DeptNo = item.DeptNo;

                db.Employees.Update(item);
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
