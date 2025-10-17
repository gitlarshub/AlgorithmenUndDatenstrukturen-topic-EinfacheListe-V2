public class DoubleNode<T>
{
    public T Data { get; set; }
    public DoubleNode<T> Next { get; set; }
    public DoubleNode<T> Previous { get; set; }

    public DoubleNode(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class DoubleLinkedList<T>
{
    private DoubleNode<T> head;
    private DoubleNode<T> tail;

    public DoubleLinkedList()
    {
        head = null;
        tail = null;
    }

    public void Add(T data)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(data);
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
        DoubleNode<T> current = head;
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
        DoubleNode<T> newNode = new DoubleNode<T>(elementToInsert);
        DoubleNode<T> current = head;

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
        DoubleNode<T> newNode = new DoubleNode<T>(elementToInsert);
        DoubleNode<T> current = head;

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
        DoubleNode<T> current = head;
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
}