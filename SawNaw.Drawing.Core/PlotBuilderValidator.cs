using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SawNaw.Drawing.Core
{
    public class PlotBuilderValidator : AbstractValidator<PlotBuilder>
    {
        public PlotBuilderValidator()
        {
            RuleFor(x => x.Height)
                .GreaterThan(0)
                .WithMessage("Height must be greater than 0");

            RuleFor(x => x.Width)
                .GreaterThan(0)
                .WithMessage("Width must be greater than 0");

            RuleFor(x => x.Fill)
                .NotEmpty()
                .WithMessage("Must specify a character to represent a populated cell.");

            RuleFor(x => x.Empty)
                .NotEmpty()
                .WithMessage("Must specify a character to represent an empty cell.");
        }
    }
}
