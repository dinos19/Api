using Domain.Aggregate;
using Infrastructure.Context;
using Infrastructure.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.MessageRepository
{
    internal class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ApiDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}