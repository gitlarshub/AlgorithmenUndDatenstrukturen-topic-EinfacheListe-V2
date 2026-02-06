using NUnit.Framework;
using CommonDLL;
using SortingAlgorithms;
using System.Collections.Generic;
using System.Reflection;

namespace DataStructureTests
{
    [TestFixture]
    public class SortAlgorithmTests
    {
        private DoubleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
        }
        private Person[] ToArray()
        {
            var result = new List<Person>();
            var headField = typeof(DoubleLinkedList<Person>)
                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance);

            var current = headField.GetValue(list);

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
        public void BubbleSort_EmptyList_DoesNothing()
        {
            list.Sort();
            Assert.AreEqual(0, list.Count());
            Assert.AreEqual(0, ToArray().Length);
        }

        [Test]
        public void BubbleSort_EmptyList_ToArrayReturnsEmptyArray()
        {
            list.Sort();
            var arr = ToArray();
            Assert.IsEmpty(arr);
        }

        [Test]
        public void InsertionSort_SetStrategyAndSortOnEmptyList_DoesNothing()
        {
            list.sortAlgorithm = new InsertionSortStrategy<Person>();
            list.Sort();
            Assert.AreEqual(0, list.Count());
            Assert.IsEmpty(ToArray());
        }

        [Test]
        public void SortStrategy_CanBeChanged()
        {
            Assert.IsInstanceOf<BubbleSortStrategy<Person>>(list.sortAlgorithm);

            list.sortAlgorithm = new InsertionSortStrategy<Person>();

            Assert.IsInstanceOf<InsertionSortStrategy<Person>>(list.sortAlgorithm);
        }

        [Test]
        public void Get_OnEmptyList_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Test]
        public void Swap_OnEmptyList_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Swap(0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Swap(0, 1));
        }
    }
}