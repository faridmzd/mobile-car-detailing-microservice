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
   public sealed class DuplicatePassportNoError : ErrorBase
    {
        public DuplicatePassportNoError(object Id) : base((int)HttpStatusCode.Forbidden)
        {
            Message = $"Client with passport number {Id} already exists";
                
            WithMetadata(HttpContextItemKeys.StatusCode, HttpStatusCode.Forbidden);
        }
    }
}
