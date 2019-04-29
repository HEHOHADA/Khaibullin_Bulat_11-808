using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortTreeSem
{
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
    {
        private T[] heap;

        public BinaryHeap(T[] heap) => this.heap = heap;

        private void Heapify(int index, int lastindex)
        {
            int left = index * 2 + 1;
            int right = left + 1;
            int largest = index;
            if (left < lastindex && heap[left].CompareTo(heap[largest]) > 0)
                largest = left;
            if (right < lastindex && heap[right].CompareTo(heap[largest]) > 0)
                largest = right;
            if (largest != index)
            {
                Swap(heap, index, largest);
                Heapify(largest, lastindex);
            }
        }

        private void BuildHeap()
        {
            for (int i = heap.Length / 2 - 1; i >= 0; i--)
                Heapify(i, heap.Length);
        }
        public void Sort()
        {
            BuildHeap();
            for (int i = heap.Length - 1; i > 0; i--)
            {
                Swap(heap, 0, i);
                Heapify(0, i);
            }
        }

        public void SortDescending()
        {
            BuildHeapDescending();
            for (int i = heap.Length - 1; i > 0; i--)
            {
                Swap(heap, 0, i);
                HeapifyDescending(0, i);
            }
        }

        private void HeapifyDescending(int index, int lastIndex)
        {
            int left = index * 2 + 1;
            int right = left + 1;
            int smalest = index;
            if (left < lastIndex && heap[left].CompareTo(heap[index]) < 0)
                smalest = left;
            if (right < lastIndex && heap[right].CompareTo(heap[smalest]) < 0)
                smalest = right;
            if (smalest != index)
            {
                Swap(heap, index, smalest);
                HeapifyDescending(smalest, lastIndex);
            }
        }

        private void BuildHeapDescending()
        {
            for (int i = heap.Length / 2 - 1; i >= 0; i--)
                HeapifyDescending(i, heap.Length);
        }

        public void Write()
        {
            foreach (var item in heap)
                Console.WriteLine(item);
        }

        private void Swap(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in heap)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
