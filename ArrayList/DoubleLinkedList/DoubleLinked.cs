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
