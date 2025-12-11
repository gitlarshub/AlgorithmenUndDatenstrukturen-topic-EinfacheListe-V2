using AlgorithmenUndDatenstrukturen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSort<T> : ISortStragegy<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                Node<T> current = head;
                while (current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}

