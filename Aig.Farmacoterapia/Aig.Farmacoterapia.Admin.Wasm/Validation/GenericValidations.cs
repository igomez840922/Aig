using FluentValidation;
using System.Collections;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Admin.Wasm.Validation
{
    public abstract class GenericValidations<T> : AbstractValidator<T>
    {
        private const string _passwordExpression = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        private readonly IServiceProvider _serviceProvider;

        protected GenericValidations(IServiceProvider serviceProvider = null)
            => _serviceProvider = serviceProvider;

        protected IRuleBuilderOptions<T, string> IsValidEmail(Expression<Func<T, string>> expression)
             => RuleFor(expression)
                 .EmailAddress().WithMessage("El correo debe ser una dirección válida");

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
