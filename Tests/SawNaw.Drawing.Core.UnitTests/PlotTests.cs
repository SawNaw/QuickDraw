using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace SawNaw.Drawing.Core.Tests
{
    public class PlotTests
    {
        [Test]
        public void Builder_PopulatesAllCells()
        {
            var sut = GetSut();

            for (int i = 0; i < sut.Height; ++i)
            {
                for (int j = 0; j < sut.Width; ++j)
                {
                    Assert.That(sut.Contents[i, j], Is.Not.EqualTo(default(char))); 

                }
            }
        }

        [Test]
        public void Builder_PopulatesAllCells_WithEmptyCharacter()
        {
            var sut = GetSut();

            for (int i = 0; i < sut.Height; ++i)
            {
                for (int j = 0; j < sut.Width; ++j)
                {
                    Assert.That(sut.Contents[i, j], Is.EqualTo('O')); 

                }
            }
        }

        [TestCase(2, 3)]
        [TestCase(1, 3)]
        [TestCase(0, 3)]
        [TestCase(4, 0)]
        public void Fill_PopulatesCell_WithFillCharacter(int vertical, int horizontal)
        {
            var sut = GetSut();

            sut.Fill(vertical, horizontal);

            Assert.That(sut.Contents[vertical, horizontal], Is.EqualTo('Z'));

        }

        [TestCase(2, 3)]
        [TestCase(1, 2)]
        [TestCase(0, 3)]
        [TestCase(4, 0)]
        public void Fill_DoesNotPopulate_OtherCells_WithFillCharacter(int vertical, int horizontal)
        {
            var sut = GetSut();

            sut.Fill(vertical, horizontal);

            for (int i = 0; i < sut.Height; ++i)
            {
                for (int j = 0; j < sut.Width; ++j)
                {
                    if (i == vertical && j == horizontal) 
                        continue;

                    Assert.That(sut.Contents[i, j], Is.EqualTo('O'));

                }
            }
        }


        [TestCase(2, 3)]
        [TestCase(1, 2)]
        [TestCase(0, 3)]
        [TestCase(4, 0)]
        public void Remove_PopulatesCell_WithEmptyCharacter(int vertical, int horizontal)
        {
            var sut = GetSut();

            sut.Fill(vertical, horizontal);
            sut.Remove(vertical, horizontal);

            for (int i = 0; i < sut.Height; ++i)
            {
                for (int j = 0; j < sut.Width; ++j)
                {
                    if (i == vertical && j == horizontal) continue;
                    Assert.That(sut.Contents[i, j], Is.EqualTo('O'));

                }
            }
        }

        private static Plot GetSut()
        {
            return new PlotBuilder().WithEmptyCharacter('O')
                                    .WithFillCharacter('Z')
                                    .WithSideWalls('|')
                                    .HavingWidth(4)
                                    .HavingHeight(5)
                                    .Build();

        }
    }
}