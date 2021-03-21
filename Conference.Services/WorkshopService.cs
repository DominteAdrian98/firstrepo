using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Services
{
    public interface IWorkshopService
    {
     
        Workshop Add(Workshop newWorkshop);
        bool Delete(Workshop workshop);
        IEnumerable<Workshop> GetAllWorkshops();
        Workshop GetWorkshopById(int id);
        int Save();
        Workshop Update(Workshop workshopToModify);
    }
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository repo;
        public WorkshopService(IWorkshopRepository repo)
        {
            this.repo = repo;
        }
        public Workshop Add(Workshop newWorkshop)
        {
            return repo.Add(newWorkshop);
        }

        public bool Delete(Workshop workshop)
        {
            return repo.Delete(workshop);
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return repo.GetAllWorkshops();
        }

        public Workshop GetWorkshopById(int id)
        {
            return repo.GetWorkshop(id);
        }

        public int Save()
        {
            return repo.Save();
        }

        public Workshop Update(Workshop workshopToModify)
        {
            return repo.UpdateWorkshop(workshopToModify);
        }
    }
}
