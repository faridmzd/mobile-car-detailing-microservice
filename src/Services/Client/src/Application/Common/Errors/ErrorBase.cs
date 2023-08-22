using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Errors
{
    public class ErrorBase : Error
    {
        protected ErrorBase(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
