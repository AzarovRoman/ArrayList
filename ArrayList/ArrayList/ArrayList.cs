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
                expandArrayList();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddToBeginning(int value)
        {
            if (Length == _array.Length)
            {
                expandArrayList();
            }

            for (int i = Length-1; i > 0; i--)
            {
                _array[i+1] = _array[i];
            }
            Length++;
            _array[0] = value;
        }

        public void WriteToConsole()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            Console.WriteLine();
        }

        private void expandArrayList()
        {
            int[] tmpArray = new int[(int)(Length * 1.5)];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
    }
}
