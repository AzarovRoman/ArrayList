using NUnit.Framework;
using System;

namespace DoubleLinkedList.Test
{
    public class Tests
    {
        #region AddTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { }, new int[] { 1 }, 1)]
        public void AddTest(int[] array, int[] expectedArr, int value)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArr);

            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddFirstTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { }, new int[] { 6 }, 6)]
        public void AddFirstTest(int[] array, int[] expectedArr, int value)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArr);

            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddByIndexTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 6, 4, 5 }, 6, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 1, 2, 3, 4, 5 }, 6, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 6, 5 }, 6, 4)]
        public void AddByIndexTest(int[] array, int[] expectedArr, int value, int index)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArr);

            actual.Add(value, index);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropLastTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DropLastTest(int[] array, int[] expectedArray)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.DropLast();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropFirstTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void DropFirstTest(int[] array, int[] expectedArray)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.DropFirst();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropByIndexTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1 }, new int[] { }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 6, 7, 8 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7)]
        public void DropTest(int[] array, int[] expectedArray, int index)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.Drop(index);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropLastElementsTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, }, 2)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 0)]
        public void DropLastElementsTest(int[] array, int[] expectedArray, int count)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.DropLast(count);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetNodeByIndexTests
        [TestCase(new int[] { 123, 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 123 }, 5)]
        [TestCase(new int[] { 1, 2, 123, 4, 5, 6 }, 2)]
        public void GetNodeByIndexTests(int[] array, int index)
        {
            DoubleLinked list = new DoubleLinked(array);
            Node actual = list.GetNodeByIndex(index);
            Node expected = GetNodeMock(1);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region NodeMock
        public Node GetNodeMock(int i)
        {
            switch (i)
            {
                case 0:
                    return new Node(123);
                default:
                    return new Node(123);
            }
            
        }

        #endregion
    }
}