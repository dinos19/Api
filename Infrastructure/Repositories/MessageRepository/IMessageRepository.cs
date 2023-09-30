using Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.MessageRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
    }
}