using System;

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

            Shift(0, Length - 1, 1);

            Length++;
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
            Length++;
        }

        public void RemoveLastElement()
        {
            _array[Length-1] = 0;
            Length--;
            ReduceArrayList();
        }

        public void RemoveFirstElement()
        {
            Shift(1, Length, 0);

            Length--;
            ReduceArrayList();
        }

        public void RemoveByIndex(int index)
        {
            Shift(++index, Length, 0);
            Length--;
            ReduceArrayList();
        }

        public void WriteToConsole()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            Console.WriteLine();
        }

        public void RemoveElementsFromEnd(int countOfElements)
        {
            if (countOfElements > Length)
            {
                throw new ArgumentException();
            }

            Length -= countOfElements;
        }

        public void RemoveElementsFromBeginning(int countOfElements)
        {
            if (countOfElements > Length)
            {
                throw new ArgumentException();
            }

            for (int i = countOfElements; i != 0; i--)
            {
                Shift(i, Length, 0);
                Length--;
            }
        }

        public void RemoveElementByIndex(int index, int countOfElements)
        {
            if (index + 1 + countOfElements > Length)
            {
                throw new ArgumentException();
            }

            for (int i = index + countOfElements; i != index; i--)
            {
                Shift(i, Length, 0);
                Length--;
            }
        }

        public int GetLength() //реально?
        {
            return Length;
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
            for (int i = 0; i < _array.Length / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[_array.Length - i - 1];
                _array[_array.Length - i - 1] = tmp;
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
            int macIndex = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] < max)
                {
                    max = _array[i];
                    macIndex = i;
                }
            }
            return macIndex;
        }

        public void Sort()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < _array.Length; j++)
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
            for (int i = 0; i < _array.Length; i++)
            {
                int indexOfMax = i;
                for (int j = i + 1; j < _array.Length; j++)
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
                    Length--;
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
            for (int i = 0; i < arrayList.Length; i++)
            {
                Length++;
                Shift(i, Length);
                _array[i] = arrayList[i];
            }
        }

        public void AddArrayListByIndex(ArrayList arrayList, int index)
        {

            for (int i = index; i < arrayList.Length+1; i++)
            {

                Length++;
                Shift(i, Length);
                _array[i] = arrayList[i-index];
            }
        }

        /// <summary>
        /// paralel shift
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="vector">must be 1 or 0. 1 is right, 0 is left</param>
        private void Shift(int startRange, int endRange, int vector=1)
        {
            switch (vector)
            {
                case 1:
                    for (int i = endRange; i >= startRange; i--)
                    {
                        _array[i+1] = _array[i];
                    }
                    break;
                case 0:
                    for (int i = startRange; i < endRange; i++)
                    {
                        _array[i-1] = _array[i];
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void ExpandArrayList()
        {
            int[] tmpArray = new int[(int)(Length * 1.5)];
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
