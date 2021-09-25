using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class MyList<T> : IList<T> where T : IComparable
    {
        //Вузол списку
        private class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node()
            {
                Data = default(T);
                Next = null;
            }

            public Node(T value)
            {
                Data = value;
            }
        }

        private Node<T> beg;        //Початок списку
        private Node<T> end;        //Кінець списку
        public int Count { get; private set; }   //К-сть вузлів в списку

        public MyList()
        {
            Count = 0;
            beg = null;
        }
        private void RemoveFirstNode()
        {
            beg = beg.Next;
            Count--;
        }
        private void RemoveLastNode()
        {
            var find = beg;
            while (find.Next != end)
            {
                find = find.Next;
            }
            find.Next = null;
            end = find;
            Count--;
        }
        private void RemoveCenterNode(Node<T> prev, Node<T> nodeToRemove)
        {
            prev.Next = nodeToRemove.Next;
            Count--;
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> find = beg;

                for (int i = 0; i < index; i++)
                {
                    find = find.Next;
                }

                return find.Data;
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var find = beg;
                for (int i = 0; i < index; i++)
                {
                    find = find.Next;
                }

                find.Data = value;
            }
        }

        public void Add(T item)
        {
            //Якщо список пустий
            if (beg == null)
            {
                beg = new Node<T>(item);
                end = beg;
                Count++;
                return;
            }

            end.Next = new Node<T>(item);
            end = end.Next;
            Count++;
        }

        public void Clear()
        {
            beg = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (var find = beg; find != null; find = find.Next)
            {
                if (find.Data.CompareTo(item) == 0)
                {
                    return true;
                }

            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= array.Length || arrayIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> copyData = beg;
            int i;

            for (i = arrayIndex; i < array.Length; i++, copyData = copyData.Next)
            {
                array[i] = copyData.Data;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var find = beg; find != null; find = find.Next)
            {
                yield return find.Data;
            }
        }

        public int IndexOf(T item)
        {
            int i = 0;
            for (var find = beg; find != null; find = find.Next, i++)
            {
                if (find.Data.CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count + 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> find = null;
            Node<T> buf = null;
            int i;

            if (index == Count)
            {
                Add(item);
                return;
            }
            else if (index == 0)
            {
                var newBeg = new Node<T>(item);
                newBeg.Next = beg;
                beg = newBeg;
                Count++;
                return;
            }
            else
            {
                find = beg;
                for (i = 0; i < index - 1; i++)
                {
                    find = find.Next;
                }
                buf = find.Next;
                find.Next = new Node<T>(item);
                find.Next.Next = buf;
            }


        }

        public bool Remove(T item)
        {
            Node<T> prev = default;
            int i = 0;

            for (var find = beg; find != null; find = find.Next, i++)
            {
                if (find.Data.CompareTo(item) == 0)
                {
                    //Перший вузол
                    if (find == beg)
                    {
                        RemoveFirstNode();
                        return true;
                    }
                    //Останній вузол
                    else if (find == end)
                    {
                        RemoveLastNode();
                        return true;
                    }
                    //Посередені
                    else
                    {
                        RemoveCenterNode(prev, find);
                        return true;
                    }
                }
                prev = find;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count + 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var find = beg;
            Node<T> prev = default;

            //Перший вузол
            if (index == 0)
            {
                RemoveFirstNode();
                return;
            }
            //Останній вузол
            else if (index == Count - 1)
            {
                RemoveLastNode();
                return;
            }
            //Посередені
            else
            {
                for (int i = 0; i < index; i++, find = find.Next)
                {
                    prev = find;
                }
                RemoveCenterNode(prev, find);
                return;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var find = beg; find != null; find = find.Next)
            {
                yield return find.Data;
            }
        }
    }
}