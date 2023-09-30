using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query.Response
{
    public class BaseResponse
    {
        public string Payload { get; set; }
        public List<string> Errors { get; set; }
        public bool Failed { get; set; }

        public BaseResponse(bool failed, List<string> errors, string payload)
        {
            Failed = failed;
            Errors = errors;
            Payload = payload;
        }
    }
}