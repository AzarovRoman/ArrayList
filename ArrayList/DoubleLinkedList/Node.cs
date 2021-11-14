using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
        
        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }

        public override string ToString()
        {
            return $"{Value} ";
        }
    }
}
