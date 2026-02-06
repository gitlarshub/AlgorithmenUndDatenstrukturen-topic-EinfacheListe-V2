using CommonDLL;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class QuickSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableCollection<T> c)
        {
            QuickSort(c, 0, c.Count() - 1);
        }

        private void QuickSort(ISortableCollection<T> c, int links, int rechts)
        {
            if (links < rechts)
            {
                int teiler = Teile(c, links, rechts);
                QuickSort(c, links, teiler - 1);
                QuickSort(c, teiler + 1, rechts);
            }
        }

        private int Teile(ISortableCollection<T> c, int links, int rechts)
        {
            int i = links;
            int j = rechts - 1;
            T pivot = c.Get(rechts);

            do
            {
                while (c.Get(i).CompareTo(pivot) <= 0 && i < rechts)
                {
                    i++;
                }

                while (c.Get(j).CompareTo(pivot) >= 0 && j > links)
                {
                    j--;
                }

                if (i < j)
                {
                    c.Swap(i, j);
                }
            } while (i < j);

            if (c.Get(i).CompareTo(pivot) > 0)
            {
                c.Swap(i, rechts);
            }

            return i;
        }
    }
}