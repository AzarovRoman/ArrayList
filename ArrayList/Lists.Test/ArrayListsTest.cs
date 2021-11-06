using NUnit.Framework;
using System;
using Lists;

namespace Lists.Test
{
    public class Tests
    {
        #region AddTests
        [TestCase(1, new int[] { 2, 3, 4, 5}, new int[] { 2, 3, 4, 5, 1})]
        [TestCase(1, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10}, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10, 1})]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddToBeginningTests
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] {1, 2, 3, 4, 5})]
        [TestCase(1, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10 }, new int[] {1, 2, 3, 4, 5, 2, 3, 4, 5, 9, 10})]
        [TestCase(1, new int[] {  }, new int[] { 1 })]
        public void AddToBeginningTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region InsertTests
        [TestCase(1, 100, new int[] { 2, 3, 4, 5 }, new int[] {2, 100, 3, 4, 5 })]
        [TestCase(3, 100, new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4, 100, 5 })]
        public void InsertTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Insert(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 5, new int[] { 2, 3, 4, 5 })]
        [TestCase(0, 5, new int[] { 2, 3, 4, 5 })]
        public void InsertTest_WhenIndexIsZeroOrMoreThenLength_ShouldThrowsIndexOutOfRangeException(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }
        #endregion

        #region DeleteLastElementTests
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4,})]
        [TestCase(new int[] { }, new int[] { })]
        public void DeleteLastElementTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteLastElement();
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteFirstElementTests
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void DeleteFirstElementTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFirstElement();
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteByIndexTests
        [TestCase(0, new int[] { 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4 })]
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] { 2, 4, 5 })]
        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { })]
        [TestCase(5, new int[] {1, 2, 3 })]
        [TestCase(-1, new int[] { 1, 2, 3 })]
        public void DeleteByIndexTest_WhenIndexMoreThenLengthOrLessThenZero_ShouldThrowsIndexOutOfRangeException(int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        }
        #endregion

        #region DeleteElementsFromBeginningTests
        [TestCase(0, new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(3, new int[] { 2, 3, 4, 5 }, new int[] { 5 })]
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void DeleteElementsFromBeginningTest(int countOfElements, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteElementsFromBeginning();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}