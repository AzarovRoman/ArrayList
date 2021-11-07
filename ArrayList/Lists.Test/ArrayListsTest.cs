using NUnit.Framework;
using System;
using Lists;

namespace Lists.Test
{
    public class Tests
    {
        #region AddTests
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5, 1 })]
        [TestCase(1, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10 }, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10, 1 })]
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
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 2, 3, 4, 5, 2, 3, 4, 5, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 2, 3, 4, 5, 9, 10 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddToBeginningTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region InsertTests
        [TestCase(1, 100, new int[] { 2, 3, 4, 5 }, new int[] { 2, 100, 3, 4, 5 })]
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
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 2, 3, 4, })]
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
        [TestCase(5, new int[] { 1, 2, 3 })]
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

            actual.DeleteElementsFromBeginning(countOfElements);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 3, 4 }, 4)]
        public void DeleteElementsFromBeginningTest_WhenIndexMoreThenLength_ShouldThrowsArgumentException(int[] array, int count)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteElementsFromBeginning(count));
        }
        #endregion

        #region DeleteElementsByIndexTests
        [TestCase(0, 1, new int[] { 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, 2, new int[] { 2, 3, 4, 5, 6, 7, 8 }, new int[] { 2, 3, 4, 7, 8 })]
        public void DeleteElementsByIndexTest(int index, int countOfElements, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteElementsByIndex(index, countOfElements);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 3, 4 }, 2, 1)]
        public void DeleteElementsByIndexTest_WhenIndexMoreThenLength_ShouldThrowsArgumentException(int[] array, int index, int countOfElements)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteElementsByIndex(index, countOfElements));
        }
        #endregion

        #region GetIndexOfFirstMatchTests
        [TestCase(4, new int[] { 1, 2, 4, 6, 7 }, 2)]
        [TestCase(4, new int[] { 1, 2, 6, 7 }, -1)]
        public void GetIndexOfFirstMatchTests(int value, int[] array, int expected)
        {
            ArrayList actualArr = new ArrayList(array);

            int actual = actualArr.GetIndexOfFirstMatch(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ReverseTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetMaxElementTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 18)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMaxElementTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.GetMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementTest_WhenLengthIsZero_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMaxElement());
        }

        #endregion
    }
}