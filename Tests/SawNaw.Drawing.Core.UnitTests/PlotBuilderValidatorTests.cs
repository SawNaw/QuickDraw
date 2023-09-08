using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawNaw.Drawing.Core.Tests
{
    public class PlotBuilderValidatorTests
    {
        [Test]
        public void Build_InvalidWidth_FailsValidation()
        {
            var sut = new PlotBuilder().WithEmptyCharacter('O')
                                       .WithFillCharacter('Z')
                                       .WithBottomCorners('+')
                                       .WithFloor('_')
                                       .WithSideWalls('|')
                                       .HavingHeight(5);

            var result = new PlotBuilderValidator().Validate(sut);

            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public void Build_InvalidHeight_FailsValidation()
        {
            var sut = new PlotBuilder().WithEmptyCharacter('O')
                                       .WithFillCharacter('Z')
                                       .WithBottomCorners('+')
                                       .WithFloor('_')
                                       .WithSideWalls('|')
                                       .HavingWidth(5);

            var result = new PlotBuilderValidator().Validate(sut);

            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public void Build_InvalidEmpty_FailsValidation()
        {
            var sut = new PlotBuilder().WithFillCharacter('Z')
                                       .WithBottomCorners('+')
                                       .WithFloor('_')
                                       .WithSideWalls('|')
                                       .HavingWidth(5)
                                       .HavingHeight(4);

            var result = new PlotBuilderValidator().Validate(sut);

            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public void Build_InvalidFill_FailsValidation()
        {
            var sut = new PlotBuilder().WithEmptyCharacter('O')
                                       .WithBottomCorners('+')
                                       .WithFloor('_')
                                       .WithSideWalls('|')
                                       .HavingWidth(5)
                                       .HavingHeight(4);

            var result = new PlotBuilderValidator().Validate(sut);

            Assert.That(result.IsValid, Is.False);
        }
    }
}
