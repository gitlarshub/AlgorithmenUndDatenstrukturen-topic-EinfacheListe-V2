namespace CommonDLL
{
    public class Node
    {
        public Person Data { get; set; }
        public Node Next { get; set; }

        public Node(Person data)
        {
            Data = data;
            Next = null;
        }
    }
}