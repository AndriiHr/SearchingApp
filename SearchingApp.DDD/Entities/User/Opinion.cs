using SearchingApp.DDD.Entities.Shared;

namespace SearchingApp.DDD.Entities.User
{
    public class Opinion : Entity
    {
        public string Description { get; set; }

        public Project Project { get; set; }
    }
}
