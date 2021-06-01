using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Services
{
    public class ProjectService : IGeneric<Project>
    {
        private SD_CompanyContext db;

        public ProjectService(SD_CompanyContext db)
        {
            this.db = db;
        }

     
        List<Project> IGeneric<Project>.RetriveAll()
        {
            try
            {
                var projects = db.Projects.ToList();
                if (projects.Count==0)
                {
                    return null;
                }

                return projects;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        Project IGeneric<Project>.Retrive(int id)
        {
            try
            {
                var project = db.Projects.Find(id);
                if (project == null)
                {
                    return null;
                }

                return project;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Project Create(Project item)
        {
            try
            {
                db.Projects.Add(item);

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

        bool IGeneric<Project>.Delete(int id)
        {
            try
            {
                var project = db.Projects.Find(id);
                db.Projects.Remove(project);

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

        Project IGeneric<Project>.Put(Project item)
        {
            try
            {
                db.Projects.Update(item);

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
