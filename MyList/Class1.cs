using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace MyList
{
    public class Program<T>
    {
        MyList<T> myList = new MyList<T>();
 
        public void Add(T item)
        {
            myList.AddToList(item);
        }

        public int ListSize()
        {
            return this.myList.NumberofItems();
        }

        public T GetListItemOnIndex(int index)
        {
            return myList.GetItemOnIndex(index);
        }
    }

    [TestFixture]
    public class MyTests
    {
        private Program<int> _intList;
        private Program<String> _stringList;

        [SetUp]
        public void SetUp()
        {
            _intList = new Program<int>();
            _stringList = new Program<string>();
        }

        [TestCase(1)]
        public void ItemShouldBeAddedToIntegerList(int i)
        {
            this._intList.Add(i);
            Assert.AreEqual(1, _intList.ListSize());
        }

        [TestCase(2)]
        public void CorrectItemShouldbeRetrievdFromIntegerList(int i)
        {
            this._intList.Add(5);
            this._intList.Add(15);
            this._intList.Add(25);
            Assert.AreEqual(25, _intList.GetListItemOnIndex(i));
        }

        [TestCase("Anchita")]
        public void ItemShouldBeAddedToStringList(string s)
        {
            this._stringList.Add(s);
            Assert.AreEqual(1, _stringList.ListSize());
        }

        [TestCase(1)]
        public void CorrectItemShouldbeRetrievdFromStringList(int i)
        {
            this._stringList.Add("Anchita");
            this._stringList.Add("Japji");
            this._stringList.Add("Amrath");
            Assert.AreEqual("Japji", _stringList.GetListItemOnIndex(i));
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
