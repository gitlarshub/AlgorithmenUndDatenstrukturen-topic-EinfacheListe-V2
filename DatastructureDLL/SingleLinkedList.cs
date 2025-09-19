using System;
using System.Xml.Linq;
using CommonDLL;

namespace DataStructures
{
    public class SingleLinkedList
    {
        private Node head;

        public SingleLinkedList()
        {
            head = null;
        }

        public void Add(Person person)
        {
            Node newNode = new Node(person);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool Contains(Person person)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(person))
                {
                    return true;


                }
                current = current.Next;
            }
            return false;
        }
    }
}