using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aig.Farmacoterapia.Application.Common.Validation
{
    public abstract class GenericValidations<T> : AbstractValidator<T>
    {
        private const string _passwordExpression = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        private readonly IServiceProvider _serviceProvider;
        
        protected GenericValidations(IServiceProvider serviceProvider = null)
            => _serviceProvider = serviceProvider;

        protected IRuleBuilderOptions<T, string> IsValidEmail(Expression<Func<T, string>> expression)
             => RuleFor(expression)
                 .NotEmpty().WithMessage("Invalid email Address")
                 .EmailAddress().WithMessage("Invalid email Address");

        protected IRuleBuilderOptions<T, string> IsNotEmpty(Expression<Func<T, string>> expression, string message)
            => RuleFor(expression)
                .NotEmpty().WithMessage(message);

        protected IRuleBuilderOptions<T, IList> IsNotEmptyList(Expression<Func<T, IList>> expression, string message)
            => RuleFor(expression)
                .Must(collection => collection is { Count: > 0 }).WithMessage(message);

        protected IRuleBuilderOptions<T, string> Length(Expression<Func<T, string>> expression, string message,
            int min, int max)
            => RuleFor(expression)
                .Length(min, max).WithMessage(message);

        protected IRuleBuilderOptions<T, object> IsNotNull(Expression<Func<T, object>> expression, string message)
            => RuleFor(expression)
                .Must((instance) => instance != null).WithMessage(message);

        protected IRuleBuilderOptions<T, string> IsValidPhoneNumber(Expression<Func<T, string>> expression)
            => RuleFor(expression)
                .NotEmpty().WithMessage("Invalid phone number");

        protected IRuleBuilderOptions<T, string> IsValidPassword(Expression<Func<T, string>> expression)
            => RuleFor(expression)
                .Matches(_passwordExpression).WithMessage("Invalid password");
    }
}
