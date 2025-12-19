using NUnit.Framework;
using System;
using CommonDLL;
using SortingAlgorithms;

namespace DataStructureTests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<Person> _queue;
        private Person p1, p2, p3, p4, p5;

        [SetUp]
        public void Setup()
        {
            _queue = new Queue<Person>();

            p1 = new Person("Anna", "Adler", "Weiblich", 30);
            p2 = new Person("Bob", "Brown", "Männlich", 25);
            p3 = new Person("Clara", "Clark", "Weiblich", 35);
            p4 = new Person("David", "Davis", "Männlich", 25);
            p5 = new Person("Eve", "Evans", "Weiblich", 20);
        }

        [Test]
        public void Enqueue_IncreasesCount()
        {
            _queue.Enqueue(p1);
            Assert.AreEqual(1, _queue.Count());

            _queue.Enqueue(p2);
            _queue.Enqueue(p3);
            Assert.AreEqual(3, _queue.Count());
        }

        [Test]
        public void Dequeue_ReturnsElementsInFIFOOrder()
        {
            _queue.Enqueue(p1);
            _queue.Enqueue(p2);
            _queue.Enqueue(p3);

            Assert.AreEqual(p1, _queue.Dequeue());
            Assert.AreEqual(p2, _queue.Dequeue());
            Assert.AreEqual(p3, _queue.Dequeue());
        }

        [Test]
        public void Peek_ReturnsFrontElement_WithoutRemovingIt()
        {
            _queue.Enqueue(p1);
            _queue.Enqueue(p2);

            Assert.AreEqual(p1, _queue.Peek());
            Assert.AreEqual(2, _queue.Count());

            _queue.Dequeue();
            Assert.AreEqual(p2, _queue.Peek());
            Assert.AreEqual(1, _queue.Count());
        }

        [Test]
        public void IsEmpty_ReturnsTrue_WhenQueueIsEmpty()
        {
            Assert.IsTrue(_queue.IsEmpty());

            _queue.Enqueue(p1);
            Assert.IsFalse(_queue.IsEmpty());

            _queue.Dequeue();
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Peek());
        }

        [Test]
        public void Count_ReturnsZero_OnEmptyQueue()
        {
            Assert.AreEqual(0, _queue.Count());
        }

        [Test]
        public void Sort_EmptyQueue_DoesNothing()
        {
            _queue.Sort();
            Assert.AreEqual(0, _queue.Count());
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Sort_SortsElementsSoThatSmallestIsAtFront()
        {
            _queue.Enqueue(p3);
            _queue.Enqueue(p1);
            _queue.Enqueue(p4);
            _queue.Enqueue(p2);
            _queue.Enqueue(p5); 

            _queue.Sort();

            Assert.AreEqual(p5, _queue.Dequeue()); 
            Assert.AreEqual("Bob", _queue.Dequeue().Vorname); 
            Assert.AreEqual("David", _queue.Dequeue().Vorname);
            Assert.AreEqual(p1, _queue.Dequeue()); 
            Assert.AreEqual(p3, _queue.Dequeue()); 

            Assert.AreEqual(0, _queue.Count());
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Sort_MaintainsCorrectOrderAfterMultipleOperations()
        {
            _queue.Enqueue(p4); 
            _queue.Enqueue(p1); 
            _queue.Enqueue(p5); 

            _queue.Sort();

            Assert.AreEqual(p5, _queue.Dequeue());
            Assert.AreEqual(p4, _queue.Dequeue());
            Assert.AreEqual(p1, _queue.Dequeue());
        }
    }
}