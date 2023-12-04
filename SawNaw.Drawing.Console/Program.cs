using SawNaw.Drawing.Core;
using SawNaw.Drawing.Core.Drawer;

Console.WriteLine("Sample console output");
Console.WriteLine();

var drawer = new PlotDrawer(2, 2, 'w', 'c', 'f', new char[3, 1]);

var plot = new PlotBuilder().WithFloor('-')
                            .WithEmptyCharacter('.')
                            .WithFillCharacter('#')
                            .WithBottomCorners('+')
                            .WithSideWalls('|')
                            .HavingWidth(10)
                            .HavingHeight(8)
                            .InjectPlotDrawer(drawer)
                            .Build();

plot.Fill(1, 1);
plot.Fill(3, 4);

plot.Draw();

