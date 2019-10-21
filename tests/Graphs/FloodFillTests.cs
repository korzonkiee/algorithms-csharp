using Algorithms.Graphs;
using Xunit;

namespace tests.Graphs
{
    public class FloodFillTests
    {
        [Fact]
        public void Should_Find_Maximum_Flood_Fill1()
        {
            (int[,] arr, int expected) = GenerateTableRandom();
            var floodFill = new FloodFill(arr);

            var result = floodFill.FindLargestFill();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_Find_Maximum_Flood_Fill2()
        {
            (int[,] arr, int expected) = GenerateTableAllTheSame();
            var floodFill = new FloodFill(arr);

            var actual = floodFill.FindLargestFill();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Return_One_For_Table_With_Each_Different_Fields()
        {
            var arr = GenerateTableAllDifferent();
            var floodFill = new FloodFill(arr);

            var actual = floodFill.FindLargestFill();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void Should_Return_Zero_For_Empty_Table()
        {
            var floodFill = new FloodFill(new int[,] { });

            var actual = floodFill.FindLargestFill();

            Assert.Equal(0, actual);
        }

        private (int[,], int) GenerateTableRandom()
        {
            return (new int[,] {
                {0,1,2,3},
                {0,1,2,2},
                {0,1,1,1},
                {0,0,0,0},
            }, 7);
        }

        private (int[,], int) GenerateTableAllTheSame()
        {
            return (new int[,] {
                {0,0},
                {0,0},
            }, 4);
        }

        private int[,] GenerateTableAllDifferent()
        {
            return new int[,] {
                {0,1},
                {2,3}
            };
        }
    }
}