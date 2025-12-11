using AlgorithmenUndDatenstrukturen;
using SortingAlgorithms;
using System;

public class DoubleLinkedList<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> tail;
    public ISortStragegy<T> sortAlgorithm;

    public DoubleLinkedList()
    {
        head = null;
        tail = null;
        sortAlgorithm = new BubbleSort<T>();
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
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
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(elementAfter))
            {
                newNode.Next = current;
                newNode.Previous = current.Previous;
                if (current.Previous != null)
                {
                    current.Previous.Next = newNode;
                }
                else
                {
                    head = newNode;
                }
                current.Previous = newNode;
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
                newNode.Previous = current;
                if (current.Next != null)
                {
                    current.Next.Previous = newNode;
                }
                else
                {
                    tail = newNode;
                }
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