using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı 2 ile 50 karakter arasında olmalıdır.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(x => x.Price).LessThan(1000).WithMessage("Ürün Bu kadar yüksek fiyat olamaz,kontrol sağlayın");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz.");

        }
    }
}
