using NUnit.Framework;
using CommonDLL;

namespace DataStructureTests
{
    public class DoubleLinkedTests
    {
        private DoubleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
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
            Person person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            Person person3 = new Person("Petra", "Müller", "Weiblich", 32);
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
            Person person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            Person person3 = new Person("Petra", "Müller", "Weiblich", 32);
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
            Person person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            Person person3 = new Person("Petra", "Müller", "Weiblich", 32);
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
            Person person1 = new Person("Lars", "Veljaca", "Männlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "Männlich", 30);
            Person person3 = new Person("Petra", "Müller", "Weiblich", 32);
            list.Add(person1);
            list.Add(person2);
            list.InsertBefore(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1), "person1 soll an Position 0 sein.");
            Assert.AreEqual(1, list.PosOfElement(person3), "person3 soll an Position 1 sein.");
            Assert.AreEqual(2, list.PosOfElement(person2), "person2 soll an Position 2 sein.");
        }

    }
}