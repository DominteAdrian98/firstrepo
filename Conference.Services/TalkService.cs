using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Conference.Services
{
    public interface ITalkService
    {
        Talk Add(Talk newTalk);
        bool Delete(Talk talk);
        IEnumerable<Talk> GetAllTalks();
        Talk getTalkById(int id);
        int Save();
        Talk Update(Talk talkToModify);
    }
    public class TalkService : ITalkService
    {
        private readonly ITalkRepository repo;
        public TalkService(ITalkRepository repo)
        {
            this.repo = repo;
        }

        public Talk Add(Talk newTalk)
        {
            return repo.Add(newTalk);
        }

        public bool Delete(Talk talk)
        {
            return repo.Delete(talk);
        }

        public IEnumerable<Talk> GetAllTalks()
        {
            return repo.GetAllTalks();
        }

        public Talk getTalkById(int id)
        {
            return repo.GetTalk(id);
        }

        public int Save()
        {
            return repo.Save();
        }

        public Talk Update(Talk talkToModify)
        {
            return repo.UpdateTalk(talkToModify);
        }
    }
}