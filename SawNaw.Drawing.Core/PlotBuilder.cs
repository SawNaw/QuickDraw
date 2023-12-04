using SawNaw.Drawing.Core.Drawer;
using System.Diagnostics.CodeAnalysis;

namespace SawNaw.Drawing.Core
{
    [ExcludeFromCodeCoverage]
    public class PlotBuilder
    {
        public char Floor { get; private set; }
        public char Walls { get; private set; }
        public char Corners { get; private set; }
        public char Empty { get; private set; }
        public char Fill { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IPlotDrawer Drawer { get; private set; }

        public PlotBuilder WithFloor(char c)
        {
            this.Floor = c;
            return this;
        }

        public PlotBuilder WithSideWalls(char c)
        {
            this.Walls = c;
            return this;
        }

        public PlotBuilder WithBottomCorners(char c)
        {
            this.Corners = c;
            return this;
        }

        public PlotBuilder WithEmptyCharacter(char c)
        {
            this.Empty = c;
            return this;
        }

        public PlotBuilder WithFillCharacter(char c)
        {
            this.Fill = c;
            return this;
        }

        public PlotBuilder HavingWidth(int nonZeroWidth)
        {
            this.Width = nonZeroWidth;
            return this;
        }

        public PlotBuilder HavingHeight(int nonZeroHeight)
        {
            this.Height = nonZeroHeight;
            return this;
        }

        public PlotBuilder InjectPlotDrawer(IPlotDrawer drawer)
        {
            this.Drawer = drawer;
            return this;
        }

        public Plot Build()
        {
            var validator = new PlotBuilderValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                throw new InvalidOperationException($"{string.Join(Environment.NewLine, result.Errors)}");
            }

            return new Plot(Floor, Walls, Corners, Empty, Fill, Width, Height, Drawer);
        }
    }
}