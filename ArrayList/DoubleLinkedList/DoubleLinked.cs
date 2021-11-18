using System;

namespace DoubleLinkedList
{
    public class DoubleLinked
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tail;

        public DoubleLinked()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinked(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public DoubleLinked(int[] array)
        {
            if (array.Length == 0)
            {
                Length = 0;
                _root = null;
                _tail = _root;
            }
            else
            {
                Node node = new Node(array[0]);
                _root = node;
                for (int i = 1; i < array.Length; i++)
                {
                    node.Next = new Node(array[i]);
                    node.Next.Prev = node;
                    node = node.Next;
                }
                _tail = node;
                Length = array.Length;
            }
        }

        public int this[int index]
        {
            get 
            {
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node res = GetNodeByIndex(index);
                return res.Value;
            }
            set 
            {
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node res = GetNodeByIndex(index);
                res.Value = value;
            }
        }

        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail.Next.Prev = _tail;
                _tail = _tail.Next;
            }
            Length++;
        }

        public void AddFirst(int value)
        {
            if(_root != null)
            {
                _root.Prev = new Node(value);
                _root.Prev.Next = _root;
                _root = _root.Prev;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }
            Length++;
        }

        public void Add(int value, int index)
        {
            int len = Length;
            if (index > len - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index != 0)
                {
                    Node crntNode = GetNodeByIndex(index);
                    Node newNode = new Node(value);
                    newNode.Next = crntNode;
                    newNode.Prev = crntNode.Prev;
                    crntNode.Prev = newNode;
                    newNode.Prev.Next = newNode;
                }
                else if (index == 0)
                {
                    AddFirst(value);
                }
            }
            Length++;
        }

        public void DropLast()
        {
            if (_root != null && _root.Next != null)
            {
                _tail.Prev.Next = null;
                _tail = _tail.Prev;
                _tail.Next = null;

            }
            else if (_root.Next == null) 
            {
                _root = null;
                _tail = null;
            }
            Length--;
        }

        public void DropFirst()
        {
            if (Length > 1)
            {
                _root = _root.Next;
                _root.Prev.Next = null;
                _root.Prev = null;
            }
            else if (Length == 1)
            {
                _root = null;
                _tail = null;
            }
            Length--;
        }

        public void Drop(int index)
        {
            if (index < Length)
            {
                if (index >= 0 && Length > 1)
                {
                    Node crntNode = GetNodeByIndex(index);
                    if (_root != crntNode && _tail != crntNode)
                    {
                        crntNode.Next.Prev = crntNode.Prev;
                        crntNode.Prev.Next = crntNode.Next;
                    }
                    else if (_root == crntNode)
                    {
                        _root = _root.Next;
                        _root.Prev.Next = null;
                        _root.Prev = null;
                    }
                    else if (_tail == crntNode)
                    {
                        _tail = _tail.Prev;
                        _tail.Next.Prev = null;
                        _tail.Next = null;
                    }
                }
                else if (index == 0 && Length == 1)
                {
                    _root = null;
                    _tail = null;
                    Length = 1;
                }
            }
        }

        public void Drop(Node node)
        {
            if (node.Next == null)
            {
                DropLast();
            }
            else if (node.Prev == null)
            {
                DropFirst();
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
        }

        public void DropLast(int count)
        {
            if (count > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (count < Length)
                {
                    if (Length > 1)
                    {
                        for (int i = 0; i < Length - (Length - count); i++)
                        {
                            DropLast();
                        }
                    }
                    else if (Length == 1 && count == 1)
                    {
                        _root = null;
                        _tail = null;
                    }
                }
            }
        }

        public void DropFirst(int count)
        {
            if (count > Length)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < count; i++)
            {
                DropFirst();
            }
        }

        public void DropElements(int index, int count)
        {
            if (index + count > Length)
            {
                throw new ArgumentException();
            }
            if (index + count != Length - 1)
            {
                for (int i = index; i < index + count; i++)
                {
                    Drop(index);
                }
            }
            else 
            {
                for (int i = index;i <= Length; i++)
                {
                    DropLast();
                }
            }
        }

        public int GetIndex(int value)
        {
            Node tmp = _root;
            for (int i = 0; i < Length;i++)
            {
                if (tmp.Value == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;
        }

        public void Reverse()
        {
            DoubleLinked newList = new DoubleLinked(); // не получилось без временного листа :(
            for (int i = 0; i < Length; i++)
            {
                newList.Add(_tail.Value);
                _tail = _tail.Prev;
            }
            _root = newList._root;
            _tail = newList._tail;
        }

        public int GetMax()
        {
            if (_root != null)
            {
                int max = _root.Value;
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Value > max)
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
            if (Length < 2)
            {
                return;
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < Length; i++)
                {
                    Node tTmp = tmp;
                    for (int j = i; j < Length; j++)
                    {
                        if (tTmp.Value > tTmp.Next.Value)
                        {
                            int swapValue = tTmp.Value;
                            tTmp.Value = tTmp.Next.Value;
                            tTmp.Next.Value = swapValue;
                        }
                        tTmp = tTmp.Next;
                    }
                    tTmp = tTmp.Next;
                }
            }
        }

        public int DropFirstEqual(int value)
        {
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value == value)
                {
                    Drop(tmp);
                    return i;
                }
            }
            return -1;
        }

        public int DropEquals(int value)
        {
            int res = 0;
            Node tmp = _root;
            while (tmp != null)
            {
                if (tmp.Value == value)
                {
                    res++;
                    Drop(tmp);
                }
            }
            return res;
        }

        public void AddElements(DoubleLinked list)
        {
            _tail.Next = list._root;
            _tail = list._tail;
        }

        public void AddFirstElements(DoubleLinked list)
        {
            list._tail.Next = _root;
            _root.Prev = list._tail;

            _root = list._root;
            _tail = list._tail;
        }

        public void AddElements(int index, DoubleLinked list)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = GetNodeByIndex(index);

            tmp.Prev.Next = list._root;
            list._root.Prev = tmp.Prev;
            list._tail.Next = tmp;
            tmp.Prev = list._tail;
        }

        public Node GetNodeByIndex(int index)
        {
            int len = Length;
            if (index >= len || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index < len/2)
            {
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp;
            }
            else
            {
                Node tmp = _tail;
                for (int i = 0; i < len - index - 1; i++)
                {
                    tmp = tmp.Prev;
                }
                return tmp;
            }
            return new Node();
        }

        public override bool Equals(object obj)
        {
            DoubleLinked DoubleLinked = (DoubleLinked)obj;
            
            Node tmpRoot = _root;
            Node tmp = DoubleLinked._root;

            if (tmpRoot == null && tmp == null)
            {
                return true;
            }

            while (tmpRoot != null && tmp != null)
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
