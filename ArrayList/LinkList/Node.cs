using System;

namespace LinkList
{
    class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            return $"{Value} ";
        }
    }
}
