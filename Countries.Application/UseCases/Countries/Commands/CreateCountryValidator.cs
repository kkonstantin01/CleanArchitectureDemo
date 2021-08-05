using FluentValidation;

namespace Countries.Application.UseCases.Countries.Commands
{
    public class CreateCountryValidator : AbstractValidator<CreateCountry>
    {
        public CreateCountryValidator()
        {
            RuleFor(request => request).NotNull();
            RuleFor(request => request.Item).NotNull();
            RuleFor(request => request.Item.Name).NotNull().NotEmpty().MinimumLength(4);
        }
    }
}
