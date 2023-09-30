using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMQ
{
    public interface IMessageBroker
    {
        Task<bool> PublishMessage(string UserId, string message);
    }
}