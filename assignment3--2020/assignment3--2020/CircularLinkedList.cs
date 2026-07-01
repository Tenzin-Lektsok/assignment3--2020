using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3Template
{

    class CircularLinkedList<T>
    {
        internal class Node
        {
            internal Node next;
            internal Node previous;
            internal T data;
            internal int priority;
        }

        private Node front;
        private Node back;
        private int count;

        public CircularLinkedList() // constructor
        {
            front = back = null;
            count = 0;
        }

        public void enqueue(T input, int inputPriority)
        {
            // adds an element based on priority.
            // Items with equal priority should be FIFO, but higher priorty should come first (so priority 5 jumps ahead of priority 4)

            Node newest = new Node();
            newest.data = input;
            newest.priority = inputPriority;

            if (count == 0)
            {
                front = newest;
                back = newest;
                newest.next = newest;
                newest.previous = newest;
            }
            else if (inputPriority > front.priority)
            {
                newest.next = front;
                newest.previous = back;
                front.previous = newest;
                back.next = newest;
                front = newest;
            }
            else
            {
                Node current = front;

                while (current.next != front && inputPriority <= current.next.priority)
                {
                    current = current.next;
                }

                newest.next = current.next;
                newest.previous = current;
                current.next.previous = newest;
                current.next = newest;

                if (current == back)
                {
                    back = newest;
                }
            }

            count++;
        }

        // adds an element to the tail of the queue
        public T dequeue()
        {
            if (count == 0)
            {
                return default(T);
            }

            T temp = front.data; //

            if (count == 1)
            {
                front = null;
                back = null;
            }
            else
            {
                front = front.next;
                front.previous = back;
                back.next = front;
            }

            count--;
            return temp;
        }

        public void printAll()
        {
            if (count == 0)
            {
                Console.WriteLine("Circular linked list is empty.");
                return;
            }

            Node current = front;

            while (current.next != front)// you'll need an extra condition here for a circular LL
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;
            }

            Console.WriteLine(current.data.ToString());
        }

        public void deleteAll()
        {
            // dequeue all elements.
            while (count > 0)
            {
                dequeue();
            }
        }

        public int GetCount()
        {
            return count;
        }
    }
}