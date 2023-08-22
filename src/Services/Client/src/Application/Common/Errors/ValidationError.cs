using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Errors
{
    public  class ValidationError : ErrorBase
    {
        public ValidationError(Dictionary<string, object> errors) : base((int)HttpStatusCode.Forbidden)
        {
            WithMetadata(errors);
        }
    }
}
