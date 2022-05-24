using Business.Constants;
using Entities.Concrete;
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

            RuleFor(p => p.ProductName).NotEmpty().WithMessage(ValidateRuleMessages.ProductNameNotEmpty);
            RuleFor(p => p.ProductName).MinimumLength(3).WithMessage(ValidateRuleMessages.ProductNameMinLength);
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage(ValidateRuleMessages.ProductNameGraterThan);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(20).When(p => p.CategoryId == 1).WithMessage(ValidateRuleMessages.ProductNameIfCIdGraterThan);
            //RuleFor(p => p.ProductName).Must(FirstLetterRule).WithMessage("Product name must begin with F.");

        }

        //private bool FirstLetterRule(string arg)
        //{
        //    return arg.StartsWith("F"); 
        //}
    }
}
