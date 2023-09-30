using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Query.Response;

namespace Domain.Command.Response
{
    public class UserSendMessageResponse : BaseResponse
    {
        public UserSendMessageResponse(bool failed, List<string> errors, string payload) : base(failed, errors, payload)
        {
            Failed = failed;
            Errors = errors;
            Payload = payload;
        }
    }
}