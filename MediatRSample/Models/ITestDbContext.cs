using System.Collections.Generic;
using MediatRSample.Handlers;

namespace MediatRSample.Models
{
    public interface ITestDbContext
    {
        List<User> User { get; }

        void Create(User user);
    }
}