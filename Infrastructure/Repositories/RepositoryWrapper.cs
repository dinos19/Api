using Infrastructure.Context;
using Infrastructure.Repositories.MessageRepository;
using Infrastructure.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApiDbContext dbContext;
        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository.UserRepository(dbContext);
                }
                return _user;
            }
        }

        private IMessageRepository _message;

        public IMessageRepository Message
        {
            get
            {
                if (_message == null)
                {
                    _message = new MessageRepository.MessageRepository(dbContext);
                }
                return _message;
            }
        }

        public RepositoryWrapper(ApiDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}