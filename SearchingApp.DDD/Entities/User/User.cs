using SearchingApp.DDD.Entities.Shared;
using System.Collections.Generic;

namespace SearchingApp.DDD.Entities.User
{
    public class User : Entity
    {
        private User() { }

        public User(string firstName, string lastName, string email, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;

            _projects = new List<Project>();
            _technologies = new List<Technology>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string ImageUrl { get; private set; }

        public byte[] Password { get; private set; }

        public Role Role { get; private set; }

        private ICollection<Technology> _technologies { get; set; }

        public IReadOnlyCollection<Technology> Technologies => (_technologies as List<Technology>).AsReadOnly();

        private ICollection<Project> _projects { get; set; }
        public IReadOnlyCollection<Project> Projects => (_projects as List<Project>).AsReadOnly();

        public void AssignProjectToUser(Project project)
        {
            _projects.Add(project);
        }

        public void AddTechnology(Technology technology)
        {
            _technologies.Add(technology);
        }

        public void SetPassword(string password)
        {
            Password = new byte[10];

        }
    }
}
