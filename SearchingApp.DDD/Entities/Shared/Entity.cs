namespace SearchingApp.DDD.Entities.Shared
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
