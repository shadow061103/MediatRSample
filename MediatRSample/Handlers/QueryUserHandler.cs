using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Models;

namespace MediatRSample.Handlers
{
    public class QueryUserHandler : IRequestHandler<QueryUserQuery, QueryUserResponse>
    {
        private readonly ITestDbContext _dbContext;

        public QueryUserHandler(ITestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<QueryUserResponse> Handle(QueryUserQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.User.First(r => r.Id == request.Id);

            return Task.FromResult(new QueryUserResponse()
            {
                DisplayName = user.Name
            });
        }
    }

    public class QueryUserResponse
    {
        public string DisplayName { get; set; }
    }

    public class QueryUserQuery : IRequest<QueryUserResponse>
    {
        public int Id { get; set; }
    }
}