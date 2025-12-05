using NUnit.Framework;
using CommonDLL;
using SortingAlgorithms;
using System.Collections.Generic;
using System.Reflection;

namespace DataStructureTests
{
    [TestFixture]
    public class SortingAlgorithmTests
    {
        private DoubleLinkedList<Person> list;
        private Person p1; 
        private Person p2;
        private Person p3;
        private Person p4;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();

            p1 = new Person("Lars", "Veljaca", "Männlich", 17);
            p2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            p3 = new Person("Petra", "Müller", "Weiblich", 32);
            p4 = new Person("Anna", "Adler", "Weiblich", 30);
        }

        private Person[] ToArray(DoubleLinkedList<Person> dll)
        {
            var result = new List<Person>();
            var current = typeof(DoubleLinkedList<Person>)
                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dll);

            while (current != null)
            {
                var data = current.GetType().GetProperty("Data")!.GetValue(current);
                result.Add((Person)data!);
                current = current.GetType().GetProperty("Next")!.GetValue(current);
            }
            return result.ToArray();
        }

        [Test]
        public void BubbleSort_EmptyList_DoesNothing()
        {
            list.Sort();
            Assert.AreEqual(0, ToArray(list).Length);
        }

        [Test]
        public void BubbleSort_SingleElement_RemainsUnchanged()
        {
            list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(1, arr.Length);
            Assert.AreEqual(p1, arr[0]);
        }

        [Test]
        public void BubbleSort_MultipleElements_SortsByAgeThenLastName()
        {
            list.Add(p2); list.Add(p3); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void BubbleSort_AlreadySortedList_RemainsSorted()
        {
            list.Add(p1); list.Add(p2); list.Add(p3);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void BubbleSort_ReverseOrderList_SortsCorrectly()
        {
            list.Add(p3); list.Add(p2); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void BubbleSort_DuplicateAges_SortsByLastName()
        {
            list.Add(p2); list.Add(p3); list.Add(p4); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p4, arr[1]); 
            Assert.AreEqual(p2, arr[2]); 
            Assert.AreEqual(p3, arr[3]); 
        }

        [Test]
        public void InsertionSort_EmptyList_DoesNothing()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Sort();
            Assert.AreEqual(0, ToArray(list).Length);
        }

        [Test]
        public void InsertionSort_SingleElement_RemainsUnchanged()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(1, arr.Length);
            Assert.AreEqual(p1, arr[0]);
        }

        [Test]
        public void InsertionSort_MultipleElements_SortsByAgeThenLastName()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Add(p2); list.Add(p3); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void InsertionSort_AlreadySortedList_RemainsSorted()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Add(p1); list.Add(p2); list.Add(p3);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void InsertionSort_ReverseOrderList_SortsCorrectly()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Add(p3); list.Add(p2); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
            Assert.AreEqual(p3, arr[2]);
        }

        [Test]
        public void InsertionSort_DuplicateAges_SortsByLastName()
        {
            list.sortAlgorithm = new InsertionSort<Person>();
            list.Add(p2); list.Add(p3); list.Add(p4); list.Add(p1);
            list.Sort();
            var arr = ToArray(list);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p4, arr[1]); 
            Assert.AreEqual(p2, arr[2]);
            Assert.AreEqual(p3, arr[3]); 
        }
    }
}