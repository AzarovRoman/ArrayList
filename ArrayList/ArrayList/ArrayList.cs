﻿using System;

namespace Lists
{
    public class ArrayList
    {
        public int Length { get; private set; } //длинна с точки зрения юзера

        private const int minArrayLength = 10;

        private int[] _array; //подкапотный массив

        public ArrayList()
        {
            Length = 0;
            _array = new int[minArrayLength];
        }

        public ArrayList(int element)
        {
            Length = 1;
            _array = new int[minArrayLength];
            _array[0] = element;
        }

        public ArrayList(ArrayList arrayList)
        {
            Length = arrayList.Length;
            if (arrayList.Length > minArrayLength)
            {
                _array = new int[(int)(arrayList.Length * 1.5)];
            }
            else
            {
                _array = new int[minArrayLength];
            }

            for (int i = 0; i < arrayList.Length; i++)
            {
                _array[i] = arrayList[i];
            }
        }

        public int this[int index]
        {
            get 
            {
                if (index < 0 || index > Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index > Length)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                ExpandArrayList();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddToBeginning(int value)
        {
            if (Length == _array.Length)
            {
                ExpandArrayList();
            }

            Shift(0, Length , 1);
            _array[0] = value;
        }

        public void Insert(int index, int value)
        {
            if (Length == _array.Length)
            {
                ExpandArrayList();
            }

            Shift(index, Length, 1);

            _array[index] = value;
        }

        public void DeleteLastElement()
        {
            Length--;
            ReduceArrayList();
        }

        public void DeleteFirstElement()
        {
            Shift(1, Length, 0);

            ReduceArrayList();
        }

        public void DeleteByIndex(int index)
        {
            Shift(++index, Length, 0);
            ReduceArrayList();
        }

        public void DeleteElementsFromEnd(int countOfElements)
        {
            if (countOfElements > Length)
            {
                throw new ArgumentException();
            }

            Length -= countOfElements;
        }

        public void DeleteElementsFromBeginning(int countOfElements)
        {
            if (countOfElements > Length)
            {
                throw new ArgumentException();
            }

            Shift(countOfElements, Length, 0, countOfElements);
            
        }

        public void DeleteElementByIndex(int index, int countOfElements)
        {
            if (index + 1 + countOfElements > Length)
            {
                throw new ArgumentException();
            }

            for (int i = index + countOfElements; i != index; i--)
            {
                Shift(i, Length, 0);
            }
        }

        public int GetIndexOfFirstMatch(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Reverse()
        {
            for (int i = 0; i <=Length / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = tmp;
            }
        }

        public int GetMaxElement()
        {
            int max = _array[0];

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int GetMinElement()
        {
            int min = _array[0];

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int GetIndexOfMin()
        {
            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public int GetIndexOfMax()
        {
            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void Sort()
        {
            for (int i = 0; i < Length; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] < _array[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }
                int tmpElem = _array[i];
                _array[i] = _array[indexOfMin];
                _array[indexOfMin] = tmpElem;
            }
        }

        public void SortDescending()
        {
            for (int i = 0; i < Length; i++)
            {
                int indexOfMax = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] > _array[indexOfMax])
                    {
                        indexOfMax = j;
                    }
                }
                int tmpElem = _array[i];
                _array[i] = _array[indexOfMax];
                _array[indexOfMax] = tmpElem;
            }
        }

        public int DeleteFirstMatch(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    int id = i+1;
                    Shift(id, Length, 0);
                    return i;
                }
            }
            return -1;
        }

        public int DeleteAllMatch(int value)
        {
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    int id = i + 1;
                    Shift(id, Length, 0);
                    Length--;
                    count++;
                }
            }
            return count;
        }

        public void AddArrayListToEnd(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Length;i++)
            {
                Add(arrayList[i]);
            }
        }

        public void AddArrayListToBeginning(ArrayList arrayList)
        {

            Shift(0, Length, 1, arrayList.Length);
            for (int i = 0; i < arrayList.Length; i++)
            {
                _array[i] = arrayList[i];
            }
        }

        public void AddArrayListByIndex(ArrayList arrayList, int index)
        {
            Shift(index, Length, 1, arrayList.Length);

            for (int i = index; i <= arrayList.Length + 2; i++)
            {
                _array[i] = arrayList[i - index];
            }
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if(Length != arrayList.Length)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (arrayList._array[i] != _array[i])
                {
                    return false;
                }
            }
            
            return true;
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < Length; i++)
            {
                str += $"{_array[i]} ";
            }

            return str;
        }

        /// <summary>
        /// paralel shift
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="vector">must be 1 or 0. 1 is right, 0 is left</param>
        private void Shift(int startRange, int endRange, int vector = 1, int step = 1)
        {
            switch (vector)
            {
                case 1:
                    if (_array.Length > Length+step) //проверяю что хватит длинны подкапотного массива
                    {
                        Length += step;
                    }
                    else
                    {
                        ExpandArrayList(step);
                        Length += step;
                    }

                    for (int i = endRange; i >= startRange; i--)
                    {
                        _array[i+step] = _array[i];
                    }
                    break;
                case 0:
                    while (_array.Length < Length/2) // проверяю что у массива нету "лишьней" длинны
                    {
                        ReduceArrayList();
                    }
                    Length -= step;

                    for (int i = startRange; i < endRange; i++)
                    {
                        _array[i-step] = _array[i];
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void ExpandArrayList(int count = 0)
        {
            int[] tmpArray = new int[(int)(Length+count * 1.5)];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        private void ReduceArrayList()
        {
            if ((int) (Length * 0.7) > minArrayLength && Length <= (_array.Length/2))
            {
                int[] tmpArray = new int[(int)(Length * 0.7)];

                for (int i = 0; i < _array.Length; i++)
                {
                    tmpArray[i] = _array[i];
                }
                _array = tmpArray;
            }

        }

    }
}
