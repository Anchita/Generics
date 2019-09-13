using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace MyList
{
    public class Program
    {
        MyList<int> myList = new MyList<int>();
 
        public void Add(int item)
        {
            myList.AddToList(item);
        }

        public int ListSize()
        {
            return this.myList.NumberofItems();
        }

        public int GetListItemOnIndex(int index)
        {
            return myList.GetItemOnIndex(index);
        }
    }

    [TestFixture]
    public class MyTests
    {
        private Program sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Program();
        }

        [TestCase(1)]
        public void ItemShouldBeAdded(int i)
        {
            this.sut.Add(i);
            Assert.AreEqual(1, sut.ListSize());
        }

        [TestCase(2)]
        public void CorrectItemShouldbeRetrievd(int i)
        {
            this.sut.Add(5);
            this.sut.Add(15);
            this.sut.Add(25);
            Assert.AreEqual(25, sut.GetListItemOnIndex(i));
        }
    }

    public class MyList<T>
    {
        public Queue<T> QueueList { get; set; }

        public MyList()
        {
            QueueList =new Queue<T>();
        }

        public void AddToList(T item)
        {
            this.QueueList.Enqueue(item);
        }

        public T GetItemOnIndex(int index)
        {
            return QueueList.ToArray()[index];
        }

        public int NumberofItems()
        {
            return this.QueueList.Count();
        }
    }
}
