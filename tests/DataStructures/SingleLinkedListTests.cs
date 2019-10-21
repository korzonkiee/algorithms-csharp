using Algorithms.Graphs;
using src.DataStructures;
using Xunit;

namespace tests.DataStructures
{
    public class SingleLinkedListTests
    {
        [Fact]
        public void Should_Append_To_Empty_List()
        {
            var list = new SingleLinkedList();

            list.Append(0);

            Assert.Equal(1, list.Size);
            Assert.Equal(new int[] { 0 }, list.ToArray());
        }

        [Fact]
        public void Should_Append_To_NonEmpty_List()
        {
            var list = new SingleLinkedList();

            list.Append(0);
            list.Append(1);

            Assert.Equal(2, list.Size);
            Assert.Equal(new int[] { 0, 1 }, list.ToArray());
        }

        [Fact]
        public void Should_Delete_Element_From_Single_Element_List()
        {
            var list = new SingleLinkedList();

            list.Append(1);
            list.Delete(1);

            Assert.Equal(0, list.Size);
            Assert.Equal(new int[] { }, list.ToArray());
        }

        [Fact]
        public void Should_Not_Throw_When_Deleting_From_Empty_List()
        {
            var list = new SingleLinkedList();

            list.Delete(0);

            Assert.Equal(0, list.Size);
            Assert.Equal(new int[] { }, list.ToArray());
        }

        [Fact]
        public void Should_Delete_Element_At_The_End()
        {
            var list = new SingleLinkedList();

            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Delete(3);

            Assert.Equal(2, list.Size);
            Assert.Equal(new int[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void Should_Delete_Element_At_The_Beggining()
        {
            var list = new SingleLinkedList();

            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Delete(1);

            Assert.Equal(2, list.Size);
            Assert.Equal(new int[] { 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Should_Delete_Element_In_The_Middle()
        {
            var list = new SingleLinkedList();

            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Delete(2);

            Assert.Equal(2, list.Size);
            Assert.Equal(new int[] { 1, 3 }, list.ToArray());
        }

        public void Should_Append_After_Deleting_All_Elements()
        {
            var list = new SingleLinkedList();

            list.Append(0);
            list.Append(0);
            list.Delete(0);
            list.Delete(0);
            list.Append(1);

            Assert.Equal(1, list.Size);
            Assert.Equal(new int[] { 1 }, list.ToArray());
        }

        public void Should_Not_Throw_When_Deleting_From_Empty_List_After_Appending_Some_Data()
        {
            var list = new SingleLinkedList();

            list.Append(0);
            list.Delete(0);
            list.Delete(0);

            Assert.Equal(0, list.Size);
            Assert.Equal(new int[] { }, list.ToArray());
        }

    }
}