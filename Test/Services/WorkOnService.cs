using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Services
{
    public class WorkOnService : IGenericComposite<WorksOn>
    {
        private SD_CompanyContext db;

        public WorkOnService(SD_CompanyContext db)
        {
            this.db = db;
        }


        public List<WorksOn> RetriveAll()
        {
            try
            {
                var employees = db.WorksOns.ToList();
                if (employees.Count == 0)
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

        public List<WorksOn> RetriveWithFstKey(int id)
        {
            try
            {
                var relationsFound = db.WorksOns.Where(x => x.EmpNo == id)
                    .ToList();

                if (relationsFound.Count == 0)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<WorksOn> RetriveWithSndKey(int id)
        {
            try
            {
                var relationsFound = db.WorksOns.Where(x => x.ProjectNo == id)
                    .ToList();

                if (relationsFound.Count == 0)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public WorksOn Retrive(int id1, int id2)
        {
            try
            {
                var relationsFound = db.WorksOns.FirstOrDefault(x => x.EmpNo == id1 && x.ProjectNo == id2);

                if (relationsFound == null)
                {
                    return null;
                }

                return relationsFound;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public WorksOn Create(WorksOn item)
        {
            try
            {
                var emp = db.Employees.Find(item.EmpNo);
                var proj = db.Projects.Find(item.ProjectNo);
                if (emp == null || proj == null)
                {
                    return null;
                }

                db.WorksOns.Add(item);

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

        public bool Delete(int id1, int id2)
        {
            try
            {
                var rel = db.WorksOns.FirstOrDefault(x => x.EmpNo == id1 && x.ProjectNo == id2);

                db.WorksOns.Remove(rel);

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

        public WorksOn Put(WorksOn item)
        {
            try
            {
                var rel = db.WorksOns.FirstOrDefault(x => x.EmpNo == item.EmpNo && x.ProjectNo == item.ProjectNo);

                if (rel == null)
                {
                    return null;
                }

                //db.WorksOns.Update(item);
                rel.Job = item.Job;
                rel.EnterDate = item.EnterDate;

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
