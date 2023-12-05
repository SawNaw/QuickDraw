using SawNaw.Drawing.Core.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawNaw.Drawing.Core
{
    public class Plot
    {
        public int Width => width;
        public int Height => height;
        public char[,] Contents => contents;

        private readonly char floor;
        private readonly char wall;
        private readonly char corner;
        private readonly char empty;
        private readonly char fill;
        private readonly int width;
        private readonly int height;
        private readonly char[,] contents;
        private readonly IPlotDrawer drawer;

        /// <summary>
        /// Use the <seealso cref="PlotBuilder"/> class to instantiate a new <see cref="Plot"/>.
        /// This constructor is not accessible.
        internal Plot(char floor, char wall, char corner, char empty, char fill, int width, int height, IPlotDrawer drawer)
        {
            this.floor = floor;
            this.wall = wall;
            this.corner = corner;
            this.empty = empty;
            this.fill = fill;
            this.width = width;
            this.height = height;
            this.drawer = drawer;

            contents = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    contents[i, j] = this.empty;
                }
            }
        }

        public void Draw()
        {
            drawer.Draw();
        }

        public void Fill(int verticalPosition, int horizontalPosition)
        {
            PutCharacter(verticalPosition, horizontalPosition, fill);
        }

        public void Remove(int verticalPosition, int horizontalPosition)
        {
            PutCharacter(verticalPosition, horizontalPosition, empty);
        }

        private void PutCharacter(int vertical, int horizontal, char character)
        {
            if (vertical < 0 || horizontal < 0 || vertical >= height || horizontal >= width)
            {
                throw new ArgumentOutOfRangeException($"({vertical}, {horizontal}) lies outside the valid range of (0, 0) to ({height - 1}, {width - 1}).");
            }
            contents[vertical, horizontal] = character;
        }
    }
}
