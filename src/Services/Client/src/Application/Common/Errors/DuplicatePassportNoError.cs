using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Errors
{
   public class DuplicatePassportNoError : IError
    {
        public List<IError> Reasons => new();

        public string Message => $"Customer with given PassportNo already exists";

        public Dictionary<string, object> Metadata => new();
    }
}
