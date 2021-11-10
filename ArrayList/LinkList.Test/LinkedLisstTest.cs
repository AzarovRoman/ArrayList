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
        public void InsertTest(int value, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Insert(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void InsertTest_WhenIndexMoreThanLength_ShouldThrowsIndexOutOfRangeException(int[] array, int index, int value)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }
        #endregion
    }
}