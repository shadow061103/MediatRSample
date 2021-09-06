using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Models;
using MediatRSample.Notify;

namespace MediatRSample.Handlers
{
    //IRequestHandler 只能有一個實作 可能或不會有回傳值
    //
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly ITestDbContext _dbContext;

        private readonly IMediator _mediator;

        public CreateUserCommandHandler(ITestDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Id = request.Id
            };

            _dbContext.Create(user);

            //notify
            await _mediator.Publish(new AddUserNotification(user), cancellationToken);

            return Unit.Value;
        }
    }

    public class CreateUserCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}