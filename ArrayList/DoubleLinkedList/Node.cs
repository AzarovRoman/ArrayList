using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class Node
    {
        public int Value 
        {
            get 
            {
                return Value;
            } 
            set
            {
                Value = value;
            } 
        }
        public Node Next { get; set; }
        public Node Prev { get; set; }
        
        public Node()
        {
            Next = null;
            Prev = null;
        }
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

        public override bool Equals(object obj)
        {
            Node node = (Node)obj;
            if (Value == node.Value)
            {
                return true;
            }
            return false;
        }
    }
}
