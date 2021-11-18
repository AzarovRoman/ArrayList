using NUnit.Framework;
using System;
using DoubleLinkedList;

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

        #region DropFirstElementsTests
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 4, }, 2)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 0)]
        public void DropFirstElementsTest(int[] array, int[] expectedArray, int count)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.DropFirst(count);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DropElementsByIndexTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 6, 7 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 0, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 }, 3, 3)]
        public void DropElementsByIndexTest(int[] array, int[] expectedArray, int index, int count)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

            actual.DropElements(index, count);
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
            DoubleLinked list = new DoubleLinked(array);
            int actual = list.GetIndex(value);

            Assert.AreEqual(expected, actual);
        }

        #endregion 

        #region ReverseTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2, 1, 1, 1, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectedArray);

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
            DoubleLinked list = new DoubleLinked(array);
            int actual = list.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            DoubleLinked actual = new DoubleLinked(array);
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
            DoubleLinked list = new DoubleLinked(array);
            int actual = list.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            DoubleLinked actual = new DoubleLinked(array);
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
            DoubleLinked list = new DoubleLinked(array);
            int actual = list.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            DoubleLinked actual = new DoubleLinked(array);
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
            DoubleLinked list = new DoubleLinked(array);
            int actual = list.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int[] array)
        {
            DoubleLinked actual = new DoubleLinked(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetIndexOfMax());
        }
        #endregion

        #region SortTests
        //[TestCase(new int[] { 2, 2, 8, 9, 1, 3, 9, 0, 5 }, new int[] { 0, 1, 2, 2, 3, 5, 8, 9, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortTest(int[] array, int[] expectdArray)
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked expected = new DoubleLinked(expectdArray);
            actual.Sort();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DropFirstEqualTests
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, 5)]
        [TestCase(new int[] { 1, 2, 3, 8, 5, 6, 0 }, 3, 2)]
        [TestCase(new int[] { 10, 2, 3, 8, 0, 6, 7 }, 10, 0)]
        [TestCase(new int[] { -10000 }, -10000, 0)]
        public void DropFirstEqualTest(int[] array, int value, int expected)
        {
            DoubleLinked list = new DoubleLinked(array);
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
        public void DropAllEqualsTest(int[] array, int value, int expected) // int[] expectedList,
        {
            DoubleLinked list = new DoubleLinked(array);
            //LinkedList newList = new LinkedList(expectedList);
            int actual = list.DropEquals(value);

            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(newList, list);
        }

        #endregion

        #region AddFirstDoubleLinkedTests
        [TestCase(new int[] { 1, 2, 3, 4}, new int[] { -2, -1, 0}, new int[] { -2, -1, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { -2, -1, 0 }, new int[] { -2, -1, 0 })]
        [TestCase(new int[] { -2, -1, 0 }, new int[] { }, new int[] { -2, -1, 0 })]
        public void AddFirstDoubleLinkedTest(int[] array, int[] sArray, int[] expectedArr )
        {
            DoubleLinked actual = new DoubleLinked(array);
            DoubleLinked list = new DoubleLinked(sArray);
            DoubleLinked expected = new DoubleLinked(expectedArr);

            actual.AddFirstElements(list);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddDoubleLinkedTests
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 },  new int[] { -2, -1, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] {  }, new int[] { 1, 2, 3, 4 })]
        public void AddDoubleLinkedTest(int[] array, int[] sArray, int[] expectedArr)
        {
            DoubleLinked actual = new DoubleLinked(array); // тот в который добавляем
            DoubleLinked list = new DoubleLinked(sArray); // тот КОТОРЫЙ добавляем
            DoubleLinked expected = new DoubleLinked(expectedArr); // с чем сравниваем

            actual.AddElements(list);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddDoubleLinkedByIndexTests
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 }, new int[] { -2, 1, 2, 3, 4, - 1, 0 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { }, new int[] { 1, 2, 3, 4 }, 2)]
        public void AddDoubleLinkedByIndexTest(int[] array, int[] sArray, int[] expectedArr, int index)
        {
            DoubleLinked actual = new DoubleLinked(array); // тот в который добавляем
            DoubleLinked list = new DoubleLinked(sArray); // тот КОТОРЫЙ добавляем
            DoubleLinked expected = new DoubleLinked(expectedArr); // с чем сравниваем

            actual.AddElements(index, list);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { -2, -1, 0 }, new int[] { 1, 2, 3, 4 }, 100)]
        public void AddDoubleLinkedByIndex_WhenRootIsNull_ShouldThrowIndexOutOfRangeException(int[] array, int[] sArray, int index)
        {
            DoubleLinked actual = new DoubleLinked(array); // тот в который добавляем
            DoubleLinked list = new DoubleLinked(sArray); // тот КОТОРЫЙ добавляем

            Assert.Throws<IndexOutOfRangeException>(()=> actual.AddElements(index, list));
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