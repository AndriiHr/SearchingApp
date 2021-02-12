using SearchingApp.DDD.Entities.Shared;
using System;
using System.Collections.Generic;

namespace SearchingApp.DDD.Entities.User
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        private ICollection<Opinion> _opinions { get; set; } = new List<Opinion>();
        public IReadOnlyCollection<Opinion> Opinions => (_opinions as List<Opinion>).AsReadOnly();
        public ICollection<User> Users { get; set; }

        public int OpinionsCount { get { return Opinions.Count; } }

        public void AddOpinion(Opinion opinion)
        {
            _opinions.Add(opinion);
        }
    }
}
