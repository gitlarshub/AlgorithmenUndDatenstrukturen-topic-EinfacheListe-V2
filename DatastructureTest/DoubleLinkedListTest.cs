using NUnit.Framework;
using CommonDLL;
using System.Collections.Generic;
using System.Reflection;

namespace DataStructureTests
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        private DoubleLinkedList<Person> list;
        private Person p1, p2, p3, p4;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
            p1 = new Person("Lars", "Veljaca", "Männlich", 17);
            p2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            p3 = new Person("Petra", "Müller", "Weiblich", 32);
            p4 = new Person("Anna", "Adler", "Weiblich", 30);
        }

        private Person[] ToArray()
        {
            var result = new List<Person>();
            var current = typeof(DoubleLinkedList<Person>)
                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(list);

            while (current != null)
            {
                var data = current.GetType().GetProperty("Data")!.GetValue(current);
                result.Add((Person)data!);
                current = current.GetType().GetProperty("Next")!.GetValue(current);
            }
            return result.ToArray();
        }

        [Test]
        public void Count_EmptyList_ReturnsZero()
        {
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void Get_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Test]
        public void Get_ThrowsOnOutOfRangeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(0)); // leere Liste
        }

        [Test]
        public void Swap_ThrowsOnInvalidIndices()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Swap(0, 1));
        }

        [Test]
        public void Sort_EmptyList_DoesNothing()
        {
            list.Sort();
            Assert.AreEqual(0, list.Count());
        }
    }
}