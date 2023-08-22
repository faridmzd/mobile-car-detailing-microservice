using Client.Application.Common.Errors;
using FluentResults;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Common.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ResultBase
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var failures = _validators
                    .Select(v => v.Validate(request))
                    .Where(v => v != null && v.IsValid != true)
                    .SelectMany(e => e.Errors)
                    .GroupBy(x => x.PropertyName)
                    .Select(x => x.First())
                    .ToDictionary(f => f.PropertyName, f => (object)f.ErrorMessage);


                if (failures.Any())
                {
                    return (dynamic)Result.Fail(new ValidationError(failures));
                }
            }


            return await next();

        }

    }
}
