using NUnit.Framework;
using SortingAlgorithms;
using CommonDLL;
using System;
using System.Collections.Generic;

namespace DataStructureAndSortingTests
{
    [TestFixture]
    public class QuickSortTests
    {
        private class TestCollection<T> : ISortableCollection<T> where T : IComparable<T>
        {
            private List<T> items = new List<T>();

            public void Add(T item)
            {
                items.Add(item);
            }

            public int Count() => items.Count;

            public T Get(int index) => items[index];

            public void Swap(int index1, int index2)
            {
                T temp = items[index1];
                items[index1] = items[index2];
                items[index2] = temp;
            }

            public List<T> ToList() => new List<T>(items);
        }

        [Test]
        public void QuickSort_SortsIntegersAscending()
        {
            var collection = new TestCollection<int>();
            collection.Add(5);
            collection.Add(3);
            collection.Add(8);
            collection.Add(1);
            collection.Add(7);
            collection.Add(2);
            collection.Add(6);
            collection.Add(4);

            var sorter = new QuickSortStrategy<int>();
            sorter.Sort(collection);

            var sortedList = collection.ToList();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, sortedList);
        }

        [Test]
        public void QuickSort_SortsPersonsByAgeThenLastName()
        {
            var collection = new TestCollection<Person>();
            collection.Add(new Person("Alice", "Smith", "Female", 30));
            collection.Add(new Person("Bob", "Johnson", "Male", 25));
            collection.Add(new Person("Charlie", "Brown", "Male", 30));
            collection.Add(new Person("David", "Williams", "Male", 25));
            collection.Add(new Person("Eve", "Davis", "Female", 35));

            var sorter = new QuickSortStrategy<Person>();
            sorter.Sort(collection);

            var sortedList = collection.ToList();
            var expected = new List<Person>
            {
                new Person("Bob", "Johnson", "Male", 25),
                new Person("David", "Williams", "Male", 25),
                new Person("Charlie", "Brown", "Male", 30),
                new Person("Alice", "Smith", "Female", 30),
                new Person("Eve", "Davis", "Female", 35)
            };

            for (int i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(expected[i].Alter, sortedList[i].Alter);
                Assert.AreEqual(expected[i].Nachname, sortedList[i].Nachname);
            }
        }

        [Test]
        public void QuickSort_HandlesEmptyCollection()
        {
            var collection = new TestCollection<int>();
            var sorter = new QuickSortStrategy<int>();
            Assert.DoesNotThrow(() => sorter.Sort(collection));
            CollectionAssert.IsEmpty(collection.ToList());
        }

        [Test]
        public void QuickSort_HandlesSingleElement()
        {
            var collection = new TestCollection<int>();
            collection.Add(42);
            var sorter = new QuickSortStrategy<int>();
            sorter.Sort(collection);
            CollectionAssert.AreEqual(new List<int> { 42 }, collection.ToList());
        }

        [Test]
        public void QuickSort_HandlesAlreadySorted()
        {
            var collection = new TestCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);

            var sorter = new QuickSortStrategy<int>();
            sorter.Sort(collection);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, collection.ToList());
        }

        [Test]
        public void QuickSort_HandlesDuplicates()
        {
            var collection = new TestCollection<int>();
            collection.Add(3);
            collection.Add(1);
            collection.Add(3);
            collection.Add(2);
            collection.Add(2);

            var sorter = new QuickSortStrategy<int>();
            sorter.Sort(collection);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 2, 3, 3 }, collection.ToList());
        }
    }
}