using NUnit.Framework;
using DataStructures;
using CommonDLL;

namespace DataStructureTests
{
    public class Tests
    {
        private SingleLinkedList list;

        [SetUp]
        public void Setup()
        {
            list = new SingleLinkedList();
        }

        [Test]
        public void AddPerson_ShouldAddPersonToTheList()
        {
            Person person = new Person("Lars", "Veljaca", "M�nnlich", 17);
            list.Add(person);
            Assert.IsTrue(list.Contains(person), "Die Person sollte in der Liste sein.");
        }

        [Test]
        public void ContainsPerson_WhenListIsEmpty_ReturnFalse()
        {
            Person person = new Person("Petra", "M�ller", "Weiblich", 32);
            Assert.IsFalse(list.Contains(person), "Die leere Liste sollte keine Person enthalten.");
        }

        [Test]
        public void ContainsPerson_WhenPersonNotInTheList_ReturnFalse()
        {
            Person person1 = new Person("Lars", "Veljaca", "M�nnlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "M�nnlich", 30);
            list.Add(person1);
            Assert.IsFalse(list.Contains(person2), "Die Person sollte nicht in der Liste sein.");
        }

        [Test]
        public void AddMultiplePersons_ShouldContainAll()
        {
            Person person1 = new Person("Lars", "Veljaca", "M�nnlich", 17);
            Person person2 = new Person("Ferdinand", "Willi", "M�nnlich", 30);
            Person person3 = new Person("Petra", "M�ller", "Weiblich", 32);
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            Assert.IsTrue(list.Contains(person1), "Person 1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person 2 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person3), "Person 3 sollte in der Liste enthalten sein.");
        }
    }
}