using NUnit.Framework;
using System;
using CommonDLL;

public class StackTests
{
    [TestFixture]
    public class IntStackTests
    {
        private Stack<int> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<int>();
        }

        [Test]
        public void Push_IncreasesCount()
        {
            _stack.Push(1);

            Assert.AreEqual(1, _stack.Count());
        }

        [Test]
        public void Pop_RemovesAndReturnsTop()
        {
            _stack.Push(1);
            _stack.Push(2);

            Assert.AreEqual(2, _stack.Pop());
            Assert.AreEqual(1, _stack.Count());
        }

        [Test]

        public void Peek_ReturnsTopWithoutRemoving()
        {
            _stack.Push(1);

            Assert.AreEqual(1, _stack.Peek());
            Assert.AreEqual(1, _stack.Count());
        }

        [Test]
        public void IsEmpty_TrueWhenEmpty()
        {
            Assert.IsTrue(_stack.IsEmpty());
        }

        [Test]
        public void IsEmpty_FalseWhenNotEmpty()
        {
            _stack.Push(1);

            Assert.IsFalse(_stack.IsEmpty());
        }

        [Test]
        public void Pop_ThrowsWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Peek_ThrowsWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void Get_ReturnsElementAtIndex()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(3, _stack.Get(0));
            Assert.AreEqual(2, _stack.Get(1));
            Assert.AreEqual(1, _stack.Get(2));
        }

        [Test]
        public void Get_ThrowsForInvalidIndex()
        {
            _stack.Push(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => _stack.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _stack.Get(1));
        }

        [Test]
        public void Swap_ExchangesElements()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _stack.Swap(0, 2);

            Assert.AreEqual(1, _stack.Get(0));
            Assert.AreEqual(2, _stack.Get(1));
            Assert.AreEqual(3, _stack.Get(2));
        }

        [Test]
        public void Swap_SameIndexDoesNothing()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Swap(0, 0);

            Assert.AreEqual(2, _stack.Get(0));
            Assert.AreEqual(1, _stack.Get(1));
        }

        [Test]
        public void Swap_ThrowsForInvalidIndices()
        {
            _stack.Push(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => _stack.Swap(0, 1));
        }

        [Test]
        public void Sort_SortsInAscendingOrderFromTop()
        {
            _stack.Push(3);
            _stack.Push(1);
            _stack.Push(5);
            _stack.Push(2);
            _stack.Push(4);
            _stack.Sort();

            Assert.AreEqual(1, _stack.Get(0));
            Assert.AreEqual(2, _stack.Get(1));
            Assert.AreEqual(3, _stack.Get(2));
            Assert.AreEqual(4, _stack.Get(3));
            Assert.AreEqual(5, _stack.Get(4));
        }
    }

    [TestFixture]
    public class PersonStackTests
    {
        private Stack<Person> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<Person>();
        }

        [Test]
        public void Sort_SortsPersonsByAgeThenNachname()
        {
            var person1 = new Person("Alice", "Smith", "F", 25);
            var person2 = new Person("Bob", "Johnson", "M", 30);
            var person3 = new Person("Charlie", "Brown", "M", 25);
            var person4 = new Person("David", "Adams", "M", 25);
            var person5 = new Person("Eve", "Williams", "F", 20);

            _stack.Push(person1);
            _stack.Push(person2);
            _stack.Push(person3);
            _stack.Push(person4);
            _stack.Push(person5);
            _stack.Sort();

            Assert.AreEqual("Eve", _stack.Get(0).Vorname);
            Assert.AreEqual(20, _stack.Get(0).Alter);
            Assert.AreEqual("David", _stack.Get(1).Vorname);
            Assert.AreEqual(25, _stack.Get(1).Alter);
            Assert.AreEqual("Adams", _stack.Get(1).Nachname);
            Assert.AreEqual("Charlie", _stack.Get(2).Vorname);
            Assert.AreEqual(25, _stack.Get(2).Alter);
            Assert.AreEqual("Brown", _stack.Get(2).Nachname);
            Assert.AreEqual("Alice", _stack.Get(3).Vorname);
            Assert.AreEqual(25, _stack.Get(3).Alter);
            Assert.AreEqual("Smith", _stack.Get(3).Nachname);
            Assert.AreEqual("Bob", _stack.Get(4).Vorname);
            Assert.AreEqual(30, _stack.Get(4).Alter);
        }
    }
}
