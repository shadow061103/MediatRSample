using System.Collections.Generic;
using MediatRSample.Handlers;

namespace MediatRSample.Models
{
    public class TestDbContext : ITestDbContext
    {
        private List<User> _user;

        public TestDbContext()
        {
            _user = new List<User>
            {
            new User {Id = 1, Name = "Test"},
            new User {Id = 2, Name = "123"},
            new User {Id = 3, Name = "asd"},
            };
        }

        public List<User> User
        {
            get
            {
                return _user;
            }
            set
            {
                this._user = new List<User>();
            }
        }

        public void Create(User user)
        {
            this._user.Add(user);
        }
    }
}