using System;

namespace DoubleLinkedList
{
    public class DoubleLinked
    {
        private Node _root;

        public DoubleLinked()
        {
            _root = null;
        }

        public DoubleLinked(int value)
        {
            _root = new Node(value);
        }

        public DoubleLinked(int[] array)
        {
            if (array.Length == 0)
            {
                _root = null;
            }
            else
            {
                Node node = new Node(array[0]);
                _root = node;
                for (int i = 1; i < array.Length; i++)
                {
                    node.Next = new Node(array[i]);
                    node = node.Next;
                }
            }
        }

        public void Add()
        {

        }

        public override bool Equals(object obj)
        {
            DoubleLinked linkedList = (DoubleLinked)obj;

            Node tmpRoot = _root;
            Node tmp = linkedList._root;

            if (tmpRoot == null && tmp == null)
            {
                return true;
            }

            while (tmpRoot != null || tmp != null)
            {
                if (tmpRoot.Value != tmp.Value)
                {
                    return false;
                }
                if ((tmpRoot.Next == null && tmp.Next != null)
                    || (tmpRoot.Next != null && tmp.Next == null))
                {
                    return false;
                }

                tmpRoot = tmpRoot.Next;
                tmp = tmp.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string str = "";
            Node tmp = _root;
            while (tmp != null)
            {
                str += $"{tmp.Value} ";
                tmp = tmp.Next;
            }
            return str;
        }
    }
}
