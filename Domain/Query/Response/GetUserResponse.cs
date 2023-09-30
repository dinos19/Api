using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query.Response
{
    public class GetUserResponse : BaseResponse
    {
        public GetUserResponse(bool failed, List<string> errors, string payload) : base(failed, errors, payload)
        {
        }
    }
}