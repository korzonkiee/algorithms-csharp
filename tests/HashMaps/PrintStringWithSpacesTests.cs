using Algorithms.Graphs;
using src.DataStructures;
using Xunit;

namespace tests.DataStructures
{
    public class PrintStringWithSpacesTests
    {

        [Fact]
        public void Should_Print_String_With_Spaces1()
        {
            var spacer = new PrintStringWithSpaces();

            string result = spacer.PrintWithSpacesWithCooldown("ABAA", 2);

            Assert.Equal(result, "AB A  A");
        }

        [Fact]
        public void Should_Print_String_With_Spaces2()
        {
            var spacer = new PrintStringWithSpaces();

            string result = spacer.PrintWithSpacesWithCooldown("AAA", 2);

            Assert.Equal(result, "A  A  A");
        }

        [Fact]
        public void Should_Print_String_With_Spaces3()
        {
            var spacer = new PrintStringWithSpaces();

            string result = spacer.PrintWithSpacesWithCooldown("ABC", 2);

            Assert.Equal(result, "ABC");
        }

        [Fact]
        public void Should_Print_String_With_Spaces4()
        {
            var spacer = new PrintStringWithSpaces();

            string result = spacer.PrintWithSpacesWithCooldown("ABAB", 2);

            Assert.Equal(result, "AB AB");
        }
    }
}