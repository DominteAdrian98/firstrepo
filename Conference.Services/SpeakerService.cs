using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Conference.Services
{
    public interface ISpeakerService
    {
        Speaker Add(Speaker newSpeaker);
        bool Delete(Speaker speaker);
        IEnumerable<Speaker> GetAllSpeakers();
        Speaker GetSpeakerById(int id);
        int Save();
        Speaker Update(Speaker speakerToModify);
    }

    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository repo;

        public SpeakerService(ISpeakerRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return repo.GetAllSpeakers();
        }

        public IEnumerable<Speaker> GetAllActiveSpeakers()
        {
           return repo.GetAllSpeakers();
  
        }


        public Speaker GetSpeakerById(int id)
        {
            return repo.GetSpeaker(id);
        }

        public Speaker Update(Speaker speakerToModify)
        {
            return repo.UpdateSpeaker(speakerToModify);
        }

        public Speaker Add(Speaker newSpeaker)
        {
            return repo.Add(newSpeaker);
        }

        public bool Delete(Speaker speaker)
        {
            return repo.Delete(speaker);
        }

        public int Save()
        {
            return repo.Save();
        }

    }
}
