using SawNaw.Drawing.Core;

Console.WriteLine("Sample console output");
Console.WriteLine();

var plot = new PlotBuilder().WithFloor('-')
                            .WithEmptyCharacter('.')
                            .WithFillCharacter('#')
                            .WithBottomCorners('+')
                            .WithSideWalls('|')
                            .HavingWidth(10)
                            .HavingHeight(8)
                            .Build();

plot.Fill(1, 1);
plot.Fill(3, 4);

plot.Draw();

