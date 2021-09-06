using MediatR;
using MediatRSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Notify
{
    public class AddUserNotification : INotification
    {
        public AddUserNotification(User person)
        {
            Id = person.Id;
            Name = person.Name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    //INotificationHandler 是一對多 可以有多個實作 不會有回傳值
    //屬於Event
    public class AddUserMailNotificationHandler : INotificationHandler<AddUserNotification>
    {
        public Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Mail Notification");
            return Task.CompletedTask;
        }
    }

    public class AddUserMqNotificationHandler : INotificationHandler<AddUserNotification>
    {
        public Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Mq Notification");
            return Task.CompletedTask;
        }
    }
}