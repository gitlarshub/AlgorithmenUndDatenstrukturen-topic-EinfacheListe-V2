using AlgorithmenUndDatenstrukturen;
using CommonDLL;
using System;

namespace SortingAlgorithms
{
    public class InsertionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        private void SwapNodes(Node<T> node1, Node<T> node2)
        {
            if (node1 == null || node2 == null)
                return;

            T temp = node1.Data;
            node1.Data = node2.Data;
            node2.Data = temp;
        }

        private Node<T> GetPrevious(Node<T> node, Node<T> head)
        {
            if (node == head) return null;

            Node<T> temp = head;
            while (temp != null && temp.Next != node)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null)
                return;

            Node<T> unsorted = head.Next;
            while (unsorted != null)
            {
                Node<T> j = unsorted;
                Node<T> prev = GetPrevious(j, head);
                while (prev != null && prev.Data.CompareTo(j.Data) > 0)
                {
                    SwapNodes(prev, j);
                    j = prev;
                    prev = GetPrevious(j, head);
                }
                unsorted = unsorted.Next;
            }
        }
    }
}