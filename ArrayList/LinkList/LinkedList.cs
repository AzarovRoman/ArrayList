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
                return count;
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

        public void Add(int index, int value)
        {
            if (index + 1 > GetLength())
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _root;
            for (int counter = 0; counter < index; counter++)
            {
                if (counter == index - 1)
                {
                    Node tmpNode = tmp;
                    tmp = tmp.Next;
                    tmpNode.Next = new Node(value);
                    tmpNode.Next.Next = tmp;
                }
                tmp = tmp.Next;
            }
        }

        public void DropLast()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _root;

            if (tmp.Next == null)
            {
                _root = null;
                tmp = null;
            }

            while (tmp != null)
            {
                if (tmp.Next.Next == null)
                {
                    tmp.Next = null;
                }
                tmp = tmp.Next;
            }
        }

        public void DropFirst()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            _root = _root.Next;
        }

        public void Drop(int index)
        {
            if (_root == null || index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _root;

            if (index == 0)
            {
                _root = _root.Next;
            }

            for (int counter = 0; counter < index; counter++)
            {
                if (counter + 1 == index)
                {
                    tmp.Next = null;
                }
                tmp = tmp.Next;
            }
        }

        public void DropLastElements(int count)
        {
            int len = GetLength();

            if (_root == null || count > len)
            {
                throw new IndexOutOfRangeException();
            }

            if(_root.Next == null)
            {
                _root = null;
            }
            if (count > 0 && len == 1)
            {
                _root = null;
            }

            if (count != 0)
            {
                Node tmp = _root;
                int resLength = len - count;

                for (int i = 1; i < resLength; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null; 
            }
            
        }

        public void DropFirstElements(int count)
        {
            Node tmp = _root;

            for (int i = 0; i < count-1; i++)
            {
                tmp = tmp.Next;
            }
            _root = tmp.Next;
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

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
