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
                int len = GetLength();

                if (index + 1 > len && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node tmp = _root;

                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
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
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
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
                    tmp.Next = tmp.Next.Next;
                }
                tmp = tmp.Next;
            }
        }

        public void DropLastElements(int count)
        {
            int len = GetLength();

            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            if (count == 0)
            {
                return;
            }
            if (count >= len)
            {
                _root = null;
            }
            else if (count < len )
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

            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int len = GetLength();

            if (count > len)
            {
                _root = null;
            }
            if (count == 0)
            {
                return;
            }
            else
            {
                Node tmp = _root;

                for (int i = 0; i < count-1; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp.Next;
            }
        }

        public void DropElementsByIndex(int index, int count)
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int len = GetLength();
            if (index + count + 1 < len && index > 0)
            {
                Node tmp = _root;
                Node tmpNode = _root;
                for (int i = 0; i < index + count; i++)
                {
                    if(i == index - 1)
                    {
                        tmpNode = tmp;
                    }
                    tmp = tmp.Next;
                }
                tmpNode.Next = tmp;
            }
            else if (index == 0)
            {
                Node tmp = _root;
                for (int i = 0; i < count; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp;
            }
            else if (index + count + 1 == len)
            {
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
            }
        }

        public int GetFirstIndexByValue(int value)
        {
            Node tmp = _root;

            for (int i = 0; tmp != null; i++)
            {
                if (tmp.Value == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;
        }

        public void Reverse()//разобраться с этим
        {
            Node oldRoot = _root;
            Node crnt;
            while (oldRoot.Next != null)
            {
                crnt = oldRoot.Next;
                oldRoot.Next = crnt.Next;
                crnt.Next = _root;
                _root = crnt;
            }
        }

        public int GetMax()
        {
            if (_root != null)
            {
                int max = _root.Value;
                Node tmp = _root;

                while (tmp != null)
                {
                    if(tmp.Value > max)
                    {
                        max = tmp.Value;
                    }
                    tmp = tmp.Next;
                }

                return max;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public int GetMin()
        {
            if (_root != null)
            {
                int min = _root.Value;
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Value < min)
                    {
                        min = tmp.Value;
                    }
                    tmp = tmp.Next;
                }

                return min;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public int GetIndexOfMin()
        {
            if (_root != null)
            {
                int max = _root.Value;
                int index = 0;
                int counter = 0;
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Value < max)
                    {
                        max = tmp.Value;
                        index = counter;
                    }
                    tmp = tmp.Next;
                    counter++;
                }

                return index;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetIndexOfMax()
        {
            if (_root != null)
            {
                int min = _root.Value;
                int index = 0;
                int counter = 0;
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Value > min)
                    {
                        min = tmp.Value;
                        index = counter;
                    }
                    tmp = tmp.Next;
                    counter++;
                }

                return index;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Sort()
        {

        }

        public void SortDesc() // Да, оно работает три миллиарда лет
        {
            if (_root != null)
            {
                LinkedList sortRoot = new LinkedList();
                int len = GetLength();
                for (int i = 0; i < len; i++)
                {
                    if (_root.Next != null)
                    {
                        int max = GetMax();

                        sortRoot.Add(max);
                        Drop(GetFirstIndexByValue(max));
                    }
                    else
                    {
                        sortRoot.Add(_root.Value);
                    }
                }

                _root = sortRoot._root;
            }
        }

        public int DropFirstEqual(int value)
        {
            int index = 0;

            if (_root != null)
            {
                Node tmp = _root;
                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return index;
                    }
                    index++;
                    tmp = tmp.Next;
                }
            }
            return -1;
        }

        public int DropAllEquals(int value)
        {
            int count = 0;

            if (_root != null)
            {
                Node tmp = _root;
                while (tmp != null)
                {
                    while (tmp.Value == value)
                    {
                        if (tmp.Next == null)
                        {
                            _root = null;
                            count++;
                            return count;
                        }
                        tmp = tmp.Next;
                        count++;
                    }

                    if (tmp.Next != null)
                    {
                        if (tmp.Next.Value == value || tmp.Value == value)
                        {
                            count++;
                            if (tmp.Next.Next != null)
                            {
                                tmp.Next = tmp.Next.Next;
                            }
                            else
                            {
                                tmp.Next = null;
                            }
                        }
                    }
                    tmp = tmp.Next;
                }
            }
            return count;
        }

        public void AddFirstLinkedList(LinkedList list) 
        {  
            if (list._root != null)
            {
                Node tmpList = list._root;
                while (tmpList.Next != null)
                {
                    tmpList = tmpList.Next;
                }
                tmpList.Next = _root;
                _root = list._root;
            }
        }

        public void AddLinkedList(LinkedList list)
        {
            if (_root != null)
            {
                Node tmp = _root;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = list._root;
            }
            else
            {
                _root = list._root;
            }
        }

        public void AddLinkedListByIndex(LinkedList list, int index)
        {
            int len = GetLength();

            if (index > len - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (_root == null)
            {
                _root = list._root;
            }
            else if (list._root != null && _root != null)
            {
                Node startList = list._root;
                Node endList = list._root;
                while (endList.Next != null)
                {
                    endList = endList.Next;
                }
                Node tmp = _root;

                for (int i = 0; i < index - 1; i++)
                {
                    tmp = tmp.Next;
                }

                Node tmpContinue = tmp.Next;
                tmp.Next = startList;
                endList.Next = tmpContinue;
            }

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
