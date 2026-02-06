using CommonDLL;
using SortingAlgorithms;
using System;

public class SingleLinkedList<T> : ISortableCollection<T> where T : IComparable<T>
{
    private Node<T> head;
    private ISortStrategy<T> sortAlgorithm;

    public SingleLinkedList()
    {
        head = null;
        sortAlgorithm = SortStrategyFactory.CreateDefault<T>();
    }

    public void Sort()
    {
        sortAlgorithm.Sort(this);
    }

    public int Count()
    {
        int count = 0;
        Node<T> current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public T Get(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        Node<T> current = head;
        for (int i = 0; i < index; i++)
        {
            if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
            current = current.Next;
        }
        if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
        return current.Data;
    }

    public void Swap(int index1, int index2)
    {
        if (index1 == index2) return;
        if (index1 > index2)
        {
            int tempIndex = index1;
            index1 = index2;
            index2 = tempIndex;
        }
        Node<T> node1 = head;
        for (int i = 0; i < index1; i++)
        {
            node1 = node1.Next;
        }
        Node<T> node2 = node1;
        for (int i = index1; i < index2; i++)
        {
            node2 = node2.Next;
        }
        if (node1 == null || node2 == null) throw new ArgumentOutOfRangeException();
        T temp = node1.Data;
        node1.Data = node2.Data;
        node2.Data = temp;
    }
}