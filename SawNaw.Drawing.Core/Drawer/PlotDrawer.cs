using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawNaw.Drawing.Core.Drawer
{
    public class PlotDrawer : IPlotDrawer
    {
        public int Height { get; init; }
        public int Width { get; init; }
        public char Wall { get; init; }
        public char Corner { get; init; }
        public char Floor { get; init; }
        public char[,] Contents { get; init; }

        public PlotDrawer(int height, int width, char wall, char corner, char floor, char[,] contents)
        {
            this.Height = height;
            this.Width = width;
            this.Wall = wall;
            this.Corner = corner;
            this.Floor = floor;
            this.Contents = contents;
        }

        public void Draw()
        {
            for (int vertical = 0; vertical < Height; ++vertical)
            {
                Console.Write(Wall);
                for (int horizontal = 0; horizontal < Width; ++horizontal)
                {
                    Console.Write(Contents[vertical, horizontal]);
                    if (horizontal == Width - 1)
                    {
                        Console.Write(Wall);
                        Console.WriteLine();
                    }
                }
            }

            if ((Corner != default(char)) && Floor != default(char))
            {
                DrawFloor();
            }
        }

        private void DrawFloor()
        {
            Console.Write(Corner);

            for (int i = 0; i < Width; ++i)
            {
                Console.Write(Floor);
            }

            Console.Write(Corner);
        }
    }
}
