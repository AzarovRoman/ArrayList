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

        [TestCase(new int[] { })]
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
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1}, 2)]
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
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, 1)]
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

        #region DropElementsByIndexTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 6, 7 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 0, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 }, 3, 3)]
        public void DropElementsByIndexTest(int[] array, int[] expectedArray, int index, int count)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DropElementsByIndex(index, count);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetFirstIndexByValueTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, -7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 0, 1)]
        [TestCase(new int[] { 2, 1, 1, 1, 1 }, 1, 1)]
        public void GetFirstIndexByValueTest(int[] array, int expected, int value)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }


        #endregion

        #region ReverseTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2, 1, 1, 1, 1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetMaxTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 10, 2, 3, 8, 5, 6, 7 }, 10)]
        [TestCase(new int[] { -10000 }, -10000)]
        public void GetMaxElementTest(int[] array, int expected)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMax());
        }
        #endregion

        #region GetMinTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 0 }, 0)]
        [TestCase(new int[] { 10, 2, 3, 8, 0, 6, 7 }, 0)]
        [TestCase(new int[] { -10000 }, -10000)]
        public void GetMinTest(int[] array, int expected)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetMin());
        }
        #endregion

        #region GetIndexOfMinTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 0 }, 6)]
        [TestCase(new int[] { 10, 2, 3, 8, 0, 6, 7 }, 4)]
        [TestCase(new int[] { -10000 }, 0)]
        public void GetIndexOfMinTest(int[] array, int expected)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetIndexOfMin());
        }

        #endregion

        #region GetIndexOfMaxTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 0 }, 3)]
        [TestCase(new int[] { 10, 2, 3, 8, 0, 6, 7 }, 0)]
        [TestCase(new int[] { -10000 }, 0)]
        public void GetIndexOfMaxTest(int[] array, int expected)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetIndexOfMax());
        }
        #endregion

        #region SortTests
        [TestCase(new int[] { 2, 2, 8, 9, 1, 3, 9, 0, 5}, new int[] { 0, 1, 2, 2, 3, 5, 8, 9, 9})]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1}, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortTest(int[] array, int[] expectdArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectdArray);
            actual.Sort();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region  
        [TestCase(new int[] { 2, 2, 8, 9, 1, 3, 9, 0, 5 }, new int[] { 9, 9, 8, 5, 3, 2, 2, 1, 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortDescTest(int[] array, int[] expectdArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectdArray);
            actual.SortDesc();

            Assert.AreEqual(expected, actual);
        }

#endregion

        #region DropFirstEqualTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, 5)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 0 }, 3, 2)]
        [TestCase(new int[] { 10, 2, 3, 8, 0, 6, 7 }, 10, 0)]
        [TestCase(new int[] { -10000 }, -10000,  0)]
        public void DropFirstEqualTest(int[] array, int value, int expected)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.DropFirstEqual(value);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropAllEqualsTests
        [TestCase(new int[] { 1, 2, 1, 1, 2, 2, 1 }, 1, 4)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, 1, 6)]
        [TestCase(new int[] { 2, 2, 2, 1, 1, 1, 1 }, 10, 0)]
        [TestCase(new int[] { 2, 2, 2, 1, 1, 1, 1 }, 1, 4)]
        [TestCase(new int[] { -10000 }, -10000, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 2 }, 2, 1)]
        public void DropAllEqualsTest(int[] array,  int value, int expected) // int[] expectedList,
        {
            LinkedList list = new LinkedList(array);
            //LinkedList newList = new LinkedList(expectedList);
            int actual = list.DropAllEquals(value);

            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(newList, list);
        }

        #endregion

        #region AddFirstLinkedListTests
        [TestCase(new int[] { 1, 2, 3, 4}, new int[] { -2, -1, 0}, new int[] { -2, -1, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { -2, -1, 0 }, new int[] { -2, -1, 0 })]
        [TestCase(new int[] { -2, -1, 0 }, new int[] { }, new int[] { -2, -1, 0 })]
        public void AddFirstLinkedListTest(int[] array, int[] sArray, int[] expectedArr )
        {
            LinkedList actual = new LinkedList(array); // тот в который добавляем
            LinkedList list = new LinkedList(sArray); // тот КОТОРЫЙ добавляем
            LinkedList expected = new LinkedList(expectedArr); // с чем сравниваем

            actual.AddFirstLinkedList(list);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddLinkedListTests
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 },  new int[] { -2, -1, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] {  }, new int[] { 1, 2, 3, 4 })]
        public void AddLinkedListTest(int[] array, int[] sArray, int[] expectedArr)
        {
            LinkedList actual = new LinkedList(array); // тот в который добавляем
            LinkedList list = new LinkedList(sArray); // тот КОТОРЫЙ добавляем
            LinkedList expected = new LinkedList(expectedArr); // с чем сравниваем

            actual.AddLinkedList(list);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddLinkedListByIndexTests
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 }, new int[] { -2, 1, 2, 3, 4, - 1, 0 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { }, new int[] { 1, 2, 3, 4 }, 2)]
        public void AddLinkedListByIndexTest(int[] array, int[] sArray, int[] expectedArr, int index)
        {
            LinkedList actual = new LinkedList(array); // тот в который добавляем
            LinkedList list = new LinkedList(sArray); // тот КОТОРЫЙ добавляем
            LinkedList expected = new LinkedList(expectedArr); // с чем сравниваем

            actual.AddLinkedListByIndex(list, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 }, 100)]
        public void AddLinkedListByIndex_WhenRootIsNull_ShouldThrowIndexOutOfRangeException(int[] array, int[] sArray, int index)
        {
            LinkedList actual = new LinkedList(array); // тот в который добавляем
            LinkedList list = new LinkedList(sArray); // тот КОТОРЫЙ добавляем

            Assert.Throws<IndexOutOfRangeException>(()=> actual.AddLinkedListByIndex(list, index));
        }
        #endregion
    }
}