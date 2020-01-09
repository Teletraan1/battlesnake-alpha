using System;
using System.Collections.Generic;

namespace Alpha.API.Seedwork
{
    public class PriorityQueue<T> where T : class, IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            queue = new List<T>();
        }

        public void Enqueue(T item)
        {
            queue.Add(item);
            var childIndex = queue.Count - 1;

            while (childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;

                if (queue[childIndex].CompareTo(queue[parentIndex]) >= 0)
                    break;

                Shift(childIndex, parentIndex);

                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (queue == null) return null as T;
            
            var lastIndex = queue.Count - 1;
            var frontItem = queue[0];
            queue[0] = queue[lastIndex];
            queue.RemoveAt(lastIndex);

            lastIndex--;
            var parentIndex = 0;
            while(true)
            {
                var childIndex = parentIndex * 2 + 1;
                if (childIndex > lastIndex) break;

                var rightChildIndex = childIndex + 1;
                if (rightChildIndex <= lastIndex && queue[rightChildIndex].CompareTo(queue[childIndex]) < 0)
                    childIndex = rightChildIndex;
                
                if (queue[parentIndex].CompareTo(queue[childIndex]) <= 0) break;
                
                Shift(parentIndex, childIndex);
                
                parentIndex = childIndex;
            }

            return frontItem;
        }

        private void Shift(int first, int second)
        {
            var temp = queue[first];
            queue[first] = queue[second];
            queue[second] = temp;
        }
    }
}
