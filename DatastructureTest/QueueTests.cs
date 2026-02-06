using NUnit.Framework;
using CommonDLL;
using SortingAlgorithms;
using System;

namespace DataStructureAndSortingTests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> _queue;

        [SetUp]
        public void Setup()
        {
            _queue = new Queue<int>();
        }

        [Test]
        public void NewQueue_IsEmpty()
        {
            Assert.IsTrue(_queue.IsEmpty());
            Assert.AreEqual(0, _queue.Count());
        }

        [Test]
        public void Enqueue_Dequeue_FIFO_Order()
        {
            _queue.Enqueue(10);
            _queue.Enqueue(20);
            _queue.Enqueue(30);

            Assert.AreEqual(10, _queue.Dequeue());
            Assert.AreEqual(20, _queue.Dequeue());
            Assert.AreEqual(30, _queue.Dequeue());
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Peek_DoesNotRemoveElement()
        {
            _queue.Enqueue(42);
            Assert.AreEqual(42, _queue.Peek());
            Assert.AreEqual(1, _queue.Count());
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void Get_ValidIndex_ReturnsCorrectValue()
        {
            _queue.Enqueue(100);
            _queue.Enqueue(200);
            _queue.Enqueue(300);

            Assert.AreEqual(100, _queue.Get(0));
            Assert.AreEqual(200, _queue.Get(1));
            Assert.AreEqual(300, _queue.Get(2));
        }

        [Test]
        public void Get_InvalidIndex_ThrowsException()
        {
            _queue.Enqueue(5);
            Assert.Throws<ArgumentOutOfRangeException>(() => _queue.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _queue.Get(1));
        }

        [Test]
        public void Sort_Ints_Ascending()
        {
            _queue.Enqueue(7);
            _queue.Enqueue(2);
            _queue.Enqueue(9);
            _queue.Enqueue(1);
            _queue.Enqueue(5);

            _queue.Sort();

            Assert.AreEqual(1, _queue.Get(0));
            Assert.AreEqual(2, _queue.Get(1));
            Assert.AreEqual(5, _queue.Get(2));
            Assert.AreEqual(7, _queue.Get(3));
            Assert.AreEqual(9, _queue.Get(4));
        }

        [Test]
        public void Sort_EmptyQueue_DoesNothing()
        {
            _queue.Sort();
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Sort_Persons_ByAgeThenLastname()
        {
            var q = new Queue<Person>();
            q.Enqueue(new Person("Ben", "Müller", "M", 19));
            q.Enqueue(new Person("Anna", "Ziegler", "W", 28));
            q.Enqueue(new Person("Clara", "Bauer", "W", 19));

            q.Sort();

            Assert.AreEqual("Clara", q.Get(0).Vorname);
            Assert.AreEqual("Ben", q.Get(1).Vorname);
            Assert.AreEqual("Anna", q.Get(2).Vorname);
        }
    }
}