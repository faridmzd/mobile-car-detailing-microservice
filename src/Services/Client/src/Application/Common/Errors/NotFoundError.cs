using Client.Application.Common.HTTP;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Errors
{
    public sealed class NotFoundError : ErrorBase
    {
        public NotFoundError(object Id):base((int)HttpStatusCode.NotFound)
        {
            Message = $"Record with identity number  {Id} not found";

        }
    }
}
