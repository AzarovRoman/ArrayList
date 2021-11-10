using NUnit.Framework;
using LinkList;
using System;

namespace LinkList.Test
{
    public class Tests
    {
        #region GetLengthTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expected)
        {
            LinkedList actualList = new LinkedList(array);
            int actual = actualList.GetLength();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddTests
        [TestCase(1, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddToStarTests
        [TestCase(1, new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 2, 3, 4 })]
        public void AddToStartTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddToStart(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region InsertTests
        [TestCase(1, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 1, 3, 4 })]
        public void AddTest(int value, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, 4)]
        public void AddTest_WhenIndexMoreThanLength_ShouldThrowsIndexOutOfRangeException(int[] array, int index, int value)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.Add(index, value));
        }
        #endregion

        #region DropLastTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DropLastTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DropLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {  })]
        public void DropLastTest_WhenListIsEmpty_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.DropLast());
        }
        #endregion

        #region DropFirstTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DropFirstTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DropFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void DropFirstTest_WhenListIsEmpty_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.DropFirst());
        }

        #endregion

        #region DropTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1 }, new int[] { }, 0)]
        public void DropTest(int[] array, int[] expectedArray, int index)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Drop(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0)]
        public void DropTest_WhenListIsEmpty_ShouldThrowsIndexOutOfRangeException(int[] array, int index)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.Drop(index));
        }

        #endregion

        #region DropLastElementsTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3}, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, }, 2)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 0)]
        public void DropLastElementsTest(int[] array, int[] expectedArray, int count)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DropLastElements(count);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropFirstElementsTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 4, }, 2)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 0)]
        public void DropFirstElementsTest(int[] array, int[] expectedArray, int count)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DropFirstElements(count);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}