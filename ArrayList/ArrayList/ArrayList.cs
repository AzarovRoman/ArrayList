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
