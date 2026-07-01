using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assignment3Template
{
    // You are probably better to use the Circular array you made in the lab
    class CircularArray<T>
    {
        T[] thisarray;
        int[] priorities;

        private int front = 0; // index of front element
        private int back = 0; // index of back element
        private int count = 0;

        public CircularArray() // constructor
        {
            thisarray = new T[20];
            priorities = new int[20];
        }

        public CircularArray(int size) // constructor with a size
        {
            thisarray = new T[size];
            priorities = new int[size];
        }

        public void enqueue(T input, int inputPriority)
        {
            // adds an element based on priority.
            // Items with equal priority should be FIFO, but higher priorty should come first (so priority 5 jumps ahead of priority 4)

            if (count == thisarray.Length)
            {
                Console.WriteLine("Circular array is full.");
                return;
            }

            int insertIndex = back;
            int current = front;

            // Find where the new item should go.
            // Higher priority items should come before lower priority items.
            for (int i = 0; i < count; i++)
            {
                if (inputPriority > priorities[current])
                {
                    insertIndex = current;
                    break;
                }

                current = (current + 1) % thisarray.Length;
            }

            int moveIndex = back;

            // Shift items one position to make space.
            while (moveIndex != insertIndex)
            {
                int previous = moveIndex - 1;

                if (previous < 0)
                {
                    previous = thisarray.Length - 1;
                }

                thisarray[moveIndex] = thisarray[previous];
                priorities[moveIndex] = priorities[previous];

                moveIndex = previous;
            }

            thisarray[insertIndex] = input;
            priorities[insertIndex] = inputPriority;

            back = (back + 1) % thisarray.Length;
            count++;
        }

        public T dequeue()
        {
            if (count == 0)
            {
                return default(T);
            }

            T temp = thisarray[front]; //

            thisarray[front] = default(T);
            priorities[front] = 0;

            front = (front + 1) % thisarray.Length;
            count--;

            return temp;
        }

        public void printAll()
        {
            int current = front;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(thisarray[current].ToString());
                current = (current + 1) % thisarray.Length;
            }
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