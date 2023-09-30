using Domain.Aggregate;
using Domain.Command.Response;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.User
{
    public class UserSendMessageCommand : IRequest<UserSendMessageResponse>
    {
        public UserSendMessageCommand(Message message)
        {
            Message = message;
        }

        public Message Message { get; set; }
    }
}