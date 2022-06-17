using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).Length(2, 100);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.Description).Length(2, 500);

            RuleFor(c => c.CategoryId).NotEmpty();
            RuleFor(c => c.CategoryId).NotNull();

            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).NotNull();
            RuleFor(c => c.Price).GreaterThan(0);
        }
    }
}
