using FluentValidation;
using Orders.Application.Commands;

namespace Orders.Application.Validation
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            //RuleFor(x => x.Address)
            //    .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("At least one product is required.")
                .ForEach(product =>
                {
                    product.ChildRules(p =>
                    {
                        p.RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
                        p.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
                    });
                });
        }
    }
}
