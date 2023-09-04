using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbouringCountries.DataStructures
{
    public class Node<T>
    {
        public T data;
        public Node<T>? next;

        public Node(T data)
        {
            this.data = data;
            next = null;
        }

        public void Enqueue(T data)
        {
            if(next == null)
            {
                next = new Node<T>(data);
            }
            else
            {
                next.Enqueue(data);
            }
        }

        public void Traverse()
        {
            Console.Write(data + "->");
            if (next != null)
            {
                next.Traverse();
            }
        }
    }
    public class LinkedListImplementation<T>: IEnumerable<T>
    {
        public Node<T>? head;
        public Node<T>? current;

        public LinkedListImplementation()
        {
            head = null;
            current = null;
        }

        public void Enqueue(T data)
        {
            if(head == null)
            {
                head = new Node<T>(data);
            }
            else
            {
                head.Enqueue(data);
            }
        }

        public T? Get(int index)
        {
            current = head;
            int count = 0;
            while(current != null)
            {
                if (count == index)
                    return current.data;
                count++;
                current = current.next;
            }
            return default(T);
        }

        public void Traverse()
        {
            if (head != null)
            {
                head.Traverse();
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
