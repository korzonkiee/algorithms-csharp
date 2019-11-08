using System;
using System.Collections.Generic;

namespace src.DataStructures
{
    public class SingleLinkedList
    {
        private class Node
        {
            public int Value { get; private set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;

        public int Size { get; private set; } = 0;

        public void Append(int e)
        {
            if (head == null)
            {
                head = new Node(e);
                tail = head;
            }
            else
            {
                tail.Next = new Node(e);
                tail = tail.Next;
            }

            Size++;
        }

        public void Delete(int e)
        {
            if (head == null)
            {
                return;
            }

            Node tmp = head;
            Node valueToDelete = null;
            Node prevValue = null;

            while (tmp != null)
            {
                if (tmp.Value == e)
                {
                    valueToDelete = tmp;
                    break;
                }

                prevValue = tmp;
                tmp = tmp.Next;
            }

            if (valueToDelete == head && valueToDelete == tail)
            {
                head = tail = null;
            }
            else if (valueToDelete == head)
            {
                head = valueToDelete.Next;
            }
            else if (valueToDelete == tail)
            {
                tail = prevValue;
                tail.Next = null;
            }
            else
            {
                var x = valueToDelete.Next;
                valueToDelete.Next = null;
                prevValue.Next = x;
            }

            Size--;
        }

        public void DeleteDuplicates()
        {
            // use your own hashset
            var hashSet = new HashSet<int>();

            var tmp = head;

            while (tmp != null)
            {
                if (hashSet.Contains(tmp.Value))
                {
                    Delete(tmp.Value);
                }
                else
                {
                    hashSet.Add(tmp.Value);
                }

                tmp = tmp.Next;
            }
        }

        public void DeleteMiddle()
        {
            var tmp = head;
            var tmp2 = head;

            while (tmp2 != null && tmp2.Next != null)
            {
                tmp = tmp.Next;
                tmp2 = tmp2.Next.Next;
            }

            Delete(tmp.Value);
        }

        public int[] ToArray()
        {
            if (head == null)
            {
                return new int[] { };
            }

            var arr = new int[Size];

            var tmp = head;
            int i = 0;
            while (tmp != null)
            {
                arr[i] = tmp.Value;

                tmp = tmp.Next;
                i++;
            }

            return arr;
        }
    }
}