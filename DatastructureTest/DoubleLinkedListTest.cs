using NUnit.Framework;
using CommonDLL;
using System.Collections.Generic;
using System.Reflection;

namespace DataStructureTests
{
    public class DoubleLinkedTests
    {
        private DoubleLinkedList<Person> list;
        private Person person1;
        private Person person2;
        private Person person3;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
            person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            person3 = new Person("Petra", "Müller", "Weiblich", 32);
        }

        private Person[] ToArray(DoubleLinkedList<Person> dll)
        {
            var result = new List<Person>();
            var current = typeof(DoubleLinkedList<Person>).GetField("head", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dll);
            while (current != null)
            {
                result.Add((Person)current.GetType().GetProperty("Data").GetValue(current));
                current = current.GetType().GetProperty("Next").GetValue(current);
            }
            return result.ToArray();
        }

        [Test]
        public void AddPerson_ShouldAddPersonToTheList()
        {
            Person person = new Person("Lars", "Veljaca", "Männlich", 17);
            list.Add(person);
            Assert.IsTrue(list.Contains(person), "Die Person sollte in der Liste sein.");
        }

        [Test]
        public void ContainsPerson_WhenListIsEmpty_ReturnFalse()
        {
            Person person = new Person("Petra", "Müller", "Weiblich", 32);
            Assert.IsFalse(list.Contains(person), "Die leere Liste sollte keine Person enthalten.");
        }

        [Test]
        public void ContainsPerson_WhenPersonNotInTheList_ReturnFalse()
        {
            Person person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            list.Add(person1);
            Assert.IsFalse(list.Contains(person2), "Die Person sollte nicht in der Liste sein.");
        }

        [Test]
        public void AddMultiplePersons_ShouldContainAll()
        {
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            Assert.IsTrue(list.Contains(person1), "Person 1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person 2 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person3), "Person 3 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertAfter_ShouldNotChangesThePositionOfElementBefore()
        {
            list.Add(person1);
            list.Add(person2);
            int positionBefore = list.PosOfElement(person1);
            list.InsertAfter(person1, person3);
            int positionAfter = list.PosOfElement(person1);
            Assert.AreEqual(positionBefore, positionAfter, "Die Position von person 1 sollte sich nicht verändern.");
            Assert.AreEqual(positionBefore + 1, list.PosOfElement(person3), "Die person3 sollte nach person1 hinzugefügt werden.");
        }

        [Test]
        public void InsertAfter_ShouldInsertInTheCorrectPosition()
        {
            list.Add(person1);
            list.Add(person2);
            list.InsertAfter(person1, person3);
            Assert.AreEqual(0, list.PosOfElement(person1), "person1 soll an Position 0 sein.");
            Assert.AreEqual(1, list.PosOfElement(person3), "person3 soll an Position 1 sein.");
            Assert.AreEqual(2, list.PosOfElement(person2), "person2 soll an Position 2 sein.");
        }

        [Test]
        public void InsertBefore_ShouldInsertInTheCorrectPosition()
        {
            list.Add(person1);
            list.Add(person2);
            list.InsertBefore(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1), "person1 soll an Position 0 sein.");
            Assert.AreEqual(1, list.PosOfElement(person3), "person3 soll an Position 1 sein.");
            Assert.AreEqual(2, list.PosOfElement(person2), "person2 soll an Position 2 sein.");
        }

        [Test]
        public void BubbleSort_EmptyList_DoesNothing()
        {
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(0, result.Length, "Eine leere Liste sollte nach dem Sortieren leer bleiben.");
        }

        [Test]
        public void BubbleSort_SingleElement_RemainsUnchanged()
        {
            list.Add(person1);
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(1, result.Length, "Die Liste sollte genau ein Element enthalten.");
            Assert.AreEqual(person1, result[0], "Das einzige Element sollte unverändert bleiben.");
        }

        [Test]
        public void BubbleSort_MultipleElements_SortsByAgeThenLastName()
        {
            list.Add(person2); 
            list.Add(person3); 
            list.Add(person1);  
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length, "Die Liste sollte drei Elemente enthalten.");
            Assert.AreEqual(person1, result[0], "Person1 (Alter 17) sollte an erster Stelle sein.");
            Assert.AreEqual(person2, result[1], "Person2 (Alter 30) sollte an zweiter Stelle sein.");
            Assert.AreEqual(person3, result[2], "Person3 (Alter 32) sollte an dritter Stelle sein.");
        }

        [Test]
        public void BubbleSort_AlreadySortedList_RemainsSorted()
        {
            list.Add(person1); 
            list.Add(person2);
            list.Add(person3);
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length, "Die Liste sollte drei Elemente enthalten.");
            Assert.AreEqual(person1, result[0], "Person1 (Alter 17) sollte an erster Stelle sein.");
            Assert.AreEqual(person2, result[1], "Person2 (Alter 30) sollte an zweiter Stelle sein.");
            Assert.AreEqual(person3, result[2], "Person3 (Alter 32) sollte an dritter Stelle sein.");
        }

        [Test]
        public void BubbleSort_ReverseOrderList_SortsCorrectly()
        {
            list.Add(person3); 
            list.Add(person2);
            list.Add(person1); 
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length, "Die Liste sollte drei Elemente enthalten.");
            Assert.AreEqual(person1, result[0], "Person1 (Alter 17) sollte an erster Stelle sein.");
            Assert.AreEqual(person2, result[1], "Person2 (Alter 30) sollte an zweiter Stelle sein.");
            Assert.AreEqual(person3, result[2], "Person3 (Alter 32) sollte an dritter Stelle sein.");
        }

        [Test]
        public void BubbleSort_DuplicateAges_SortsByLastName()
        {
            var person4 = new Person("Anna", "Adler", "Weiblich", 30); 
            list.Add(person2); 
            list.Add(person3); 
            list.Add(person4); 
            list.Add(person1); 
            list.Sort();
            var result = ToArray(list);
            Assert.AreEqual(4, result.Length, "Die Liste sollte vier Elemente enthalten.");
            Assert.AreEqual(person1, result[0], "Person1 (Alter 17) sollte an erster Stelle sein.");
            Assert.AreEqual(person4, result[1], "Person4 (Alter 30, Adler) sollte an zweiter Stelle sein.");
            Assert.AreEqual(person2, result[2], "Person2 (Alter 30, Willi) sollte an dritter Stelle sein.");
            Assert.AreEqual(person3, result[3], "Person3 (Alter 32) sollte an vierter Stelle sein.");
        }
    }
}