using NUnit.Framework;
using AlgorithmenUndDatenstrukturen;
using SortingAlgorithms;
using CommonDLL;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace DatastructureTest
{
    [TestFixture]
    public class SortAlgorithmTests
    {
        private ISortAlgorithm<Person> sorter;
        private DoubleLinkedList<Person> list;
        private Person person1;
        private Person person2; 
        private Person person3; 
        private Person person4; 

        [SetUp]
        public void Setup()
        {
            sorter = new BubbleSort<Person>();
            list = new DoubleLinkedList<Person>();

            person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            person3 = new Person("Petra", "Müller", "Weiblich", 32);
            person4 = new Person("Anna", "Adler", "Weiblich", 30);
        }

        private Node<Person> GetHead()
        {
            var headField = typeof(DoubleLinkedList<Person>)
                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance);
            return (Node<Person>)headField.GetValue(list);
        }

        // Wandelt die Liste in ein Array um
        private Person[] ToArray()
        {
            var result = new List<Person>();
            var current = GetHead();

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result.ToArray();
        }

        [Test]
        public void Sort_EmptyList_DoesNothing()
        {
            sorter.Sort(GetHead());
            var result = ToArray();
            Assert.AreEqual(0, result.Length, "Leere Liste sollte leer bleiben.");
        }

        [Test]
        public void Sort_SingleElement_RemainsUnchanged()
        {
            list.Add(person1);
            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(person1, result[0], "Einzelnes Element sollte unverändert sein.");
        }

        [Test]
        public void Sort_MultipleElements_SortsByAgeThenLastName()
        {
            list.Add(person3); 
            list.Add(person1);
            list.Add(person2);

            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person2, result[1]);
            Assert.AreEqual(person3, result[2]);
        }

        [Test]
        public void Sort_AlreadySortedList_RemainsCorrect()
        {
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);

            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person2, result[1]);
            Assert.AreEqual(person3, result[2]);
        }

        [Test]
        public void Sort_ReverseOrder_SortsCorrectly()
        {
            list.Add(person3);
            list.Add(person2);
            list.Add(person1);

            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person2, result[1]);
            Assert.AreEqual(person3, result[2]);
        }

        [Test]
        public void Sort_DuplicateAges_SortsByLastName()
        {
            list.Add(person3);
            list.Add(person4);
            list.Add(person2);
            list.Add(person1);

            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person4, result[1]); 
            Assert.AreEqual(person2, result[2]); 
            Assert.AreEqual(person3, result[3]); 
        }

        [Test]
        public void Sort_WithNullInput_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => sorter.Sort(null), "Sort should handle null input gracefully.");
        }

        [Test]
        public void Sort_TwoElements_SwapsIfNeeded()
        {
            list.Add(person2);
            list.Add(person1); 

            sorter.Sort(GetHead());
            var result = ToArray();

            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person2, result[1]);
        }
    }
}