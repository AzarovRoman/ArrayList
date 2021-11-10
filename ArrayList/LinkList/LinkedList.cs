using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class LinkedList
    {
        private Node _root;

        public LinkedList()
        {
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
        }

        public LinkedList(int[] array)
        {

            Node node = new Node(array[0]);
            _root = node;
            for (int i = 1; i < array.Length; i++)
            {
                node.Next = new Node(array[i]);
                node = node.Next;
            }
            if (array.Length == 0)
            {
                _root = null;
            }
        }

        public int this[int index]
        {
            get
            {
                if (_root == null)
                {
                    throw new IndexOutOfRangeException();
                }

                int count = 0;
                Node tmp = _root;
                while (tmp != null)
                {
                    if (count == index - 1)
                    {
                        return tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return -1;
            }
            set
            {

            }
        }

        public int GetLength()
        {
            Node tmp = _root;
            int count = 0;
            if (tmp == null)
            {
                return 0;
            }
            while (tmp != null)
            {
                count++;
                tmp = tmp.Next;
            }
            return count;
        }

        public void Add(int value)
        {
            if (_root != null)
            {
                Node tmpNode = _root;
                while (tmpNode.Next != null)
                {
                    tmpNode = tmpNode.Next;
                }
                tmpNode.Next = new Node(value);
            }
            else
            {
                _root = new Node(value);
            }
        }

        public void AddToStart(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                _root = new Node(value);
            }
        }

        public void AddByIndex(int index, int value)
        {

        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            while (linkedList._root.Next != null)
            {
                if (_root.Next == null && linkedList._root.Next != null)
                {
                    return false;
                }
                if (_root.Next != null && linkedList._root.Next == null)
                {
                    return false;
                }
                if (linkedList._root.Value != _root.Value)
                {
                    return false;
                }

                linkedList._root = linkedList._root.Next;
                _root = _root.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string result = "";
            Node tmpNode = _root;
            while (tmpNode != null)
            {
                result += $"{tmpNode.Value} ";
                tmpNode = tmpNode.Next;
            }
            return result;
        }
    }
}
