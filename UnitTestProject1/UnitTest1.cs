using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHash_1()
        {
            HashTable hat = new HashTable(16, 5);

            int s1 = hat.Put("str");
            int s2 = hat.Put("str");
            int s3 = hat.Put("str1");
            int s4 = hat.Find("str");

            Assert.AreEqual("str", hat.slots[s1]);
            Assert.AreEqual("str", hat.slots[s2]);
            Assert.AreEqual("str1", hat.slots[s3]);
            Assert.AreEqual("str", hat.slots[s4]);
        }


        [TestMethod]
        public void TestHash_2()
        {
            HashTable hat = new HashTable(16, 5);

            for (int i = 0; i < 20; i++)
                hat.Put("str");

            for(int i = 0; i < hat.size; i++)
            {
                Assert.AreEqual("str", hat.slots[i]);
            }
        }


        [TestMethod]
        public void TestHash_3()
        {
            HashTable hat = new HashTable(16, 5);

            int s1 = hat.Put("amb");
            int s2 = hat.Put("sur");
            int s3 = hat.Put("pop");
            int s4 = hat.Put("jaz");

            Assert.AreEqual("amb", hat.slots[s1]);
            Assert.AreEqual("sur", hat.slots[s2]);
            Assert.AreEqual("pop", hat.slots[s3]);
            Assert.AreEqual("jaz", hat.slots[s4]);
        }


        [TestMethod]
        public void TestHash_4()
        {
            HashTable hat = new HashTable(16, 5);

            int s1 = hat.Put("amb");
            int s2 = hat.Put("sur");
            int s3 = hat.Put("pop");
            int s4 = hat.Put("jaz");

            int s5 = hat.Find("amb");
            int s6 = hat.Find("sur");
            int s7 = hat.Find("pop");
            int s8 = hat.Find("jaz");

            Assert.AreEqual("amb", hat.slots[s5]);
            Assert.AreEqual("sur", hat.slots[s6]);
            Assert.AreEqual("pop", hat.slots[s7]);
            Assert.AreEqual("jaz", hat.slots[s8]);

            Assert.AreEqual(s1, s5);
            Assert.AreEqual(s2, s6);
            Assert.AreEqual(s3, s7);
            Assert.AreEqual(s4, s8);
        }


        [TestMethod]
        public void TestHash_5()
        {
            HashTable hat1 = new HashTable(16, 5);
            HashTable hat2 = new HashTable(16, 5);

            int s1 = hat1.HashFun("amb");
            int s2 = hat2.Put("amb");

            Assert.AreEqual(s1, s2);
        }


        [TestMethod]
        public void TestHash_6()
        {
            HashTable hat1 = new HashTable(5, 3);

            int s1 = hat1.HashFun("amb1");
            int s2 = hat1.HashFun("amb2");
            int s3 = hat1.HashFun("amb3");
            int s4 = hat1.HashFun("amb4");
            int s5 = hat1.HashFun("amb5");
            int s6 = hat1.HashFun("amb5");

            Assert.AreEqual(s1, s2);
            Assert.AreEqual(s1, s3);
            Assert.AreEqual(s1, s4);
            Assert.AreEqual(s1, s5);
            Assert.AreEqual(s1, s6);
        }


        [TestMethod]
        public void TestHash_7()
        {
            HashTable hat = new HashTable(3, 5);

            int s1 = hat.Put("amb");
            int s2 = hat.Put("amb");
            int s3 = hat.Put("gee");

            Assert.AreEqual("amb", hat.slots[s1]);
            Assert.AreEqual("amb", hat.slots[s2]);
            Assert.AreEqual("gee", hat.slots[s3]);

            int s4 = hat.Put("gee");

            Assert.AreEqual(-1, s4);
        }


        [TestMethod]
        public void TestHash_8()
        {
            HashTable hat = new HashTable(3, 5);

            int s1 = hat.Put("amb");
            int f1 = hat.Find("amb");
            int s2 = hat.Put("amb");
            int s3 = hat.Put("gee");
            int f2 = hat.Find("amb");

            Assert.AreEqual(false, f1 == f2);
            Assert.AreEqual(false, s1 == s2);
            Assert.AreEqual(false, s1 == s3);
            Assert.AreEqual(false, s2 == s3);
        }


        [TestMethod]
        public void TestHash_9()
        {
            HashTable hat = new HashTable(3, 5);

            int s1 = hat.Put("amb");
            int f1 = hat.Find("amb");
            int s2 = hat.Put("amb");
            int s3 = hat.Put("gee");
            int f2 = hat.Find("amb");

            Assert.AreEqual(false, f1 == f2);
            Assert.AreEqual(false, s1 == s2);
            Assert.AreEqual(false, s1 == s3);
            Assert.AreEqual(false, s2 == s3);
        }
    }
}
