using CommonDLL;
using System;

namespace SortingAlgorithms
{
    public class InsertionSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableCollection<T> c)
        {
            int count = c.Count();
            for (int i = 1; i <= count - 1; i++)
            {
                T t = c.Get(i);
                for (int j = i - 1; j >= 0; j--)
                {
                    if (t.CompareTo(c.Get(j)) < 0)
                    {
                        c.Swap(j, j + 1);
                    }
                }
            }
        }
    }
}