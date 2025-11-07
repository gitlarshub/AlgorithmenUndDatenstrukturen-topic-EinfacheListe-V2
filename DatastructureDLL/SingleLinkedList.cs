using AlgorithmenUndDatenstrukturen;
using CommonDLL;
using SortingAlgorithms;
using System;

public class SingleLinkedList<T> where T : IComparable<T>
{
    private Node<T> head;
    private ISortAlgorithm<T> sortAlgorithm;

    public SingleLinkedList()
    {
        head = null;
        sortAlgorithm = new BubbleSort<T>();
    }
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }
    public bool Contains(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        if (head != null && head.Data.Equals(elementAfter))
        {
            newNode.Next = head;
            head = newNode;
            return;
        }
        Node<T> current = head;
        while (current != null && current.Next != null)
        {
            if (current.Next.Data.Equals(elementAfter))
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }
    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        Node<T> newNode = new Node<T>(elementToInsert);
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(elementBefore))
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }

    public int PosOfElement(T element)
    {
        Node<T> current = head;
        int position = 0;
        while (current != null)
        {
            if (current.Data.Equals(element))
            {
                return position;
            }
            current = current.Next;
            position++;
        }
        return -1;
    }
    public void Sort()
    {
        sortAlgorithm.Sort(head);
    }
}
