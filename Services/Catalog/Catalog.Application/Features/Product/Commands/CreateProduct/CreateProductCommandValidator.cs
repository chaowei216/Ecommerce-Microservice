using FluentValidation;

namespace Catalog.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(p => p.Summary).NotEmpty().WithMessage("Summary is required");
        RuleFor(p => p.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(p => p.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(p => p.Brands).NotEmpty().WithMessage("Brand is required");
        RuleFor(p => p.Types).NotEmpty().WithMessage("Type is required");
    }
}