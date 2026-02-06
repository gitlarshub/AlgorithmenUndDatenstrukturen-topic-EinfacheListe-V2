using CommonDLL;
using SortingAlgorithms;
using System;

public class Stack<T> : ISortableCollection<T> where T : IComparable<T>
{
    private Node<T> top;
    private ISortStrategy<T> sortAlgorithm;

    public Stack() 
    {
        top = null;
        sortAlgorithm = SortStrategyFactory.CreateDefault<T>(); 
    }

    public void Push(T data) 
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = top;
        top = newNode;
    }

    public T Pop() 
    {
        if (top == null) throw new InvalidOperationException("Stack is empty");
        T data = top.Data;
        top = top.Next;
        return data;
    }

    public T Peek()
    {
        if (top == null) throw new InvalidOperationException("Stack is empty");
        return top.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Sort() 
    {
        sortAlgorithm.Sort(this);
    }

    public int Count() 
    {
        int count = 0;
        Node<T> current = top;
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
        Node<T> current = top;
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
        Node<T> node1 = top;
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
        T tempData = node1.Data;
        node1.Data = node2.Data;
        node2.Data = tempData;
    }
}