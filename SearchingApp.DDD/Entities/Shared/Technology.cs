namespace SearchingApp.DDD.Entities.Shared
{
    public class Technology: Entity
    {
        public Technologies TechnologyPart { get; set; }
        public string Description { get; set; }

        public User.User User { get; set; }
    }
}
