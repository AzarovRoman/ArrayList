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

        #region GetMinElementTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 1)]
        [TestCase(new int[] { 100, 2, 3, 18, 4 }, 2)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMinElementTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.GetMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinElementTest_WhenLengthIsZero_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMinElement());
        }

        #endregion

        #region GetIndexOfMinTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 0)]
        [TestCase(new int[] { 100, 2, 3, 18, 4 }, 1)]
        [TestCase(new int[] { 1 }, 0)]
        public void GetIndexOfMinTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinTest_WhenLengthIsZero_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetIndexOfMin());
        }

        #endregion

        #region GetIndexOfMaxTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 3)]
        [TestCase(new int[] { 100, 2, 3, 18, 4 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        public void GetIndexOfMaxTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxTest_WhenLengthIsZero_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetIndexOfMax());
        }

        #endregion

        #region SortTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, new int[] { 1, 2, 3, 4, 18})]
        [TestCase(new int[] { -100, -2, -3, -18, -4 }, new int[] { -100, -18, -4, -3, -2 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Sort();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region SortDescendingTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, new int[] { 18, 4, 3, 2, 1 })]
        [TestCase(new int[] { -100, -2, -3, -18, -4 }, new int[] { -2, -3, -4, -18, -100 })]
        [TestCase(new int[] { -100, -2, -3, 7, -18, -4, }, new int[] { 7, -2, -3, -4, -18, -100})]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortDescendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.SortDescending();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DeleteFirstMatchTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 3, 18)]
        [TestCase(new int[] { 100, 2, 3, 18, 4 }, -1, 5)]
        [TestCase(new int[] { }, -1, 123)]
        public void DeleteFirstMatchTest(int[] array, int expected, int value)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.DeleteFirstMatch(value);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DeleteAllMatchTests
        [TestCase(new int[] { 1, 2, 3, 18, 4 }, 1, 18)]
        [TestCase(new int[] { 100, 2, 3, 18, 4 }, 0, 5)]
        [TestCase(new int[] { }, 0, 123)]
        public void DeleteAllMatchTest(int[] array, int expected, int value)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.DeleteAllMatch(value);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddArrayListToEndTests
        [TestCase(new int[] { }, new int[] { 1, 2, 3}, new int[] { 1, 2, 3})]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, -2, -3}, new int[] { 1, 2, 3}, new int[] { -1, -2, -3, 1, 2, 3})]
        public void AddArrayListToEndTest(int[] arrayList, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(arrayList); // исходник
            ArrayList testArray = new ArrayList(array); // то что добавляем
            ArrayList expected = new ArrayList(expectedArray); // как должен выглядеть результат

            actual.AddArrayListToEnd(testArray);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddArrayListToBeginningTests
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, -1, -2, -3})]
        public void AddArrayListToBeginningTest(int[] arrayList, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(arrayList); // исходник
            ArrayList testArray = new ArrayList(array); // то что добавляем
            ArrayList expected = new ArrayList(expectedArray); // как должен выглядеть результат

            actual.AddArrayListToBeginning(testArray);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddArrayListByIndexTests
        //[TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 0)]
        [TestCase(new int[] { 1, 2, 3}, new int[] { }, new int[] { 1, 2, 3 }, 0)]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, -1, -2, -3, 3 }, 1)]
        public void AddArrayListByIndexTest(int[] arrayList, int[] array, int[] expectedArray, int index)
        {
            ArrayList actual = new ArrayList(arrayList); // исходник
            ArrayList testArray = new ArrayList(array); // то что добавляем
            ArrayList expected = new ArrayList(expectedArray); // как должен выглядеть результат

            actual.AddArrayListByIndex(testArray, index);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}