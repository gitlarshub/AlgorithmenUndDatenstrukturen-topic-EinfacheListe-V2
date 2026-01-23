using NUnit.Framework;
using SortingAlgorithms;
using CommonDLL;
using System;
using System.Collections.Generic;

namespace DataStructureAndSortingTest
{
    [TestFixture]
    public class BucketSortTests
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
        public void BucketSort_SortsIntegersAscending()
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

            var sorter = new BucketSortStrategy<int>();
            sorter.Sort(collection);

            var sortedList = collection.ToList();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, sortedList);
        }

        // BucketSort ist für numerische Werte gedacht, daher kein Test für Person, da Convert.ToDouble fehlschlagen würde.
        // Falls benötigt, müsste BucketSort für nicht-numerische Typen angepasst werden (z.B. über eine Hash-Funktion).

        [Test]
        public void BucketSort_HandlesEmptyCollection()
        {
            var collection = new TestCollection<int>();
            var sorter = new BucketSortStrategy<int>();
            Assert.DoesNotThrow(() => sorter.Sort(collection));
            CollectionAssert.IsEmpty(collection.ToList());
        }

        [Test]
        public void BucketSort_HandlesSingleElement()
        {
            var collection = new TestCollection<int>();
            collection.Add(42);
            var sorter = new BucketSortStrategy<int>();
            sorter.Sort(collection);
            CollectionAssert.AreEqual(new List<int> { 42 }, collection.ToList());
        }

        [Test]
        public void BucketSort_HandlesAlreadySorted()
        {
            var collection = new TestCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);

            var sorter = new BucketSortStrategy<int>();
            sorter.Sort(collection);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, collection.ToList());
        }

        [Test]
        public void BucketSort_HandlesDuplicates()
        {
            var collection = new TestCollection<int>();
            collection.Add(3);
            collection.Add(1);
            collection.Add(3);
            collection.Add(2);
            collection.Add(2);

            var sorter = new BucketSortStrategy<int>();
            sorter.Sort(collection);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 2, 3, 3 }, collection.ToList());
        }

        [Test]
        public void BucketSort_HandlesAllEqual()
        {
            var collection = new TestCollection<int>();
            collection.Add(5);
            collection.Add(5);
            collection.Add(5);
            collection.Add(5);

            var sorter = new BucketSortStrategy<int>();
            sorter.Sort(collection);

            CollectionAssert.AreEqual(new List<int> { 5, 5, 5, 5 }, collection.ToList());
        }
    }
}