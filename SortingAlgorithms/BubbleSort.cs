using CommonDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableCollection<T> c)
        {
            int count = c.Count();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < count - 1; i++)
                {
                    if (c.Get(i).CompareTo(c.Get(i + 1)) > 0)
                    {
                        c.Swap(i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}