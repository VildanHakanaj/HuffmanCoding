using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Huffman
{
    // Common interface for ALL non-linear data structures

    public interface IContainer<T>
    {
        void MakeEmpty();  // Reset an instance to empty
        bool Empty();      // Test if an instance is empty
        int Size();        // Return the number of items in an instance
    }

    //-----------------------------------------------------------------------------

    public interface IPriorityQueue<T> where T : IComparable
    {
        void Add(T item);  // Add an item to a priority queue
        void Remove();     // Remove the item with the highest priority
        T Front();         // Return the item with the highest priority
    }

    //-------------------------------------------------------------------------

    // Priority Queue
    // Implementation:  Binary heap and its used an array to build a binart heap


    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        private int capacity;  // Maximum number of items in a priority queue
        private T[] A;         // Array of items
        private int count;     // Number of items in a priority queue

        public PriorityQueue(int size)
        {
            capacity = size; //set the size of the array
            A = new T[size + 1];  // Indexing begins at 1 removes the 0
            count = 0; // set count to 0;
        }

        // Percolate up from position i in a priority queue

        private void PercolateUp(int i) // pass interger to get the index
        // (Worst case) time complexity: O(log n)
        {
            int child = i, parent; //child starts at i

            while (child > 1)
            {
                parent = child / 2; //parents goes up 
                if (A[child].CompareTo(A[parent]) > 0)
                // If child has a higher priority than parent
                {
                    // Swap parent and child
                    T item = A[child]; //save child in temporary value
                    A[child] = A[parent]; //set child to parent 
                    A[parent] = item;// set parent to child position
                    child = parent;  // Move up child index to parent index
                }
                else
                    // Item is in its proper position
                    return;
            }
        }


        public void Add(T item)
        // Time complexity: O(log n) log is the number of levels of the tree.
        {
            if (count < capacity)
            {
                A[++count] = item;  // Place item at the next available position
                PercolateUp(count);
            }
        }

        // Percolate down from position i in a priority queue

        private void PercolateDown(int i)
        // Time complexity: O(log n)
        {
            int parent = i, child;//start parent to child

            while (2 * parent <= count) //doesn't have a child if parent is less than the count
            // while parent has at least one child
            {
                // Select the child with the highest priority
                child = 2 * parent;    // Left child index
                if (child < count)  // Right child also exists
                    if (A[child + 1].CompareTo(A[child]) > 0)
                        // Right child has a higher priority than left child
                        child++;

                if (A[child].CompareTo(A[parent]) > 0)
                // If child has a higher priority than parent
                {
                    // Swap parent and child
                    T item = A[child];
                    A[child] = A[parent];
                    A[parent] = item;
                    parent = child;  // Move down parent index to child index
                }
                else
                    // Item is in its proper place
                    return;
            }
        }

        public void Remove()
        // Time complexity: O(log n)
        {
            if (!Empty())
            {
                // Remove item with highest priority (root) and
                // replace it with the last item
                A[1] = A[count--];

                // Percolate down the new root item
                PercolateDown(1);
            }
        }

        public T Front() //Get the front of the tree
        // Time complexity: O(1)
        {
            if (!Empty()) //if not empty
            {
                return A[1];  // Return the root item (highest priority)
            }
            else
                return default(T);
        }

        // Create a binary heap
        // Percolate down from the last parent to the root (first parent)

        private void BuildHeap() //
        // Time complexity: O(n)
        {
            int i;
            for (i = count / 2; i >= 1; i--)//
            {
                PercolateDown(i);
            }
        }

        // Sorts and returns the InputArray

        public void HeapSort(T[] inputArray)
        // Time complexity: O(n log n)
        {
            int i;

            capacity = count = inputArray.Length;

            // Copy input array to A (indexed from 1)
            for (i = capacity - 1; i >= 0; i--)
            {
                A[i + 1] = inputArray[i];
            }

            // Create a binary heap
            BuildHeap();

            // Remove the next item and place it into the input (output) array
            for (i = 0; i < capacity; i++)
            {
                inputArray[i] = Front();
                Remove();
            }
        }

        public void MakeEmpty()
        // Time complexity: O(1)
        {
            count = 0;
        }

        public bool Empty()
        // Time complexity: O(1)
        {
            return count == 0;
        }

        public int Size()
        // Time complexity: O(1)
        {
            return count;
        }
    }
}
