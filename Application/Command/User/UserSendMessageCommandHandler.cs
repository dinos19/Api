using Domain.Aggregate;
using Domain.Command.Response;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Command.User
{
    public class UserSendMessageCommandHandler : IRequestHandler<UserSendMessageCommand, UserSendMessageResponse>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserSendMessageCommandHandler(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<UserSendMessageResponse> Handle(UserSendMessageCommand request, CancellationToken cancellationToken)
        {
            //persist to db
            request.Message.MessageStatus = (int)MessageStatus.SERVER_RECIEVED;
            _repositoryWrapper.Message.Create(request.Message);
            _repositoryWrapper.Save();
            //publish message to the correct bus

            //_rabbitMqWrapper.PublishMessage(request.Message.ToUserId.ToString(), request.Message.Body);

            return Task.FromResult(new UserSendMessageResponse(false, new List<string> { "No problem" }, $"Message Sent"));
        }
    }
}