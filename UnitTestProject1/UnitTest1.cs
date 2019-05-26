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
            HashTable hat = new HashTable(5, 3);

            int s1 = hat.HashFun("amb1");
            int s2 = hat.HashFun("amb2");
            int s3 = hat.HashFun("amb3");
            int s4 = hat.HashFun("amb4");
            int s5 = hat.HashFun("amb5");
            int s6 = hat.HashFun("amb5");

            Assert.AreEqual(s1, s2);
            Assert.AreEqual(s1, s3);
            Assert.AreEqual(s1, s4);
            Assert.AreEqual(s1, s5);
            Assert.AreEqual(s1, s6);
        }


        [TestMethod]
        public void TestHash_7()
        {
            HashTable hat = new HashTable(5, 3);

            int s1a = hat.SeekSlot("amb1");
            int s1b = hat.SeekSlot("amb1");

            int p1 = hat.Put("amb1");
            int p2 = hat.Put("amb2");

            int s1c = hat.SeekSlot("amb1");
            int s2 = hat.SeekSlot("amb2");
            int s3 = hat.SeekSlot("amb3");
            
            Assert.AreEqual(true, s1a == s1b);
            Assert.AreEqual(true, s1a != s1c);
            Assert.AreEqual(true, s1a == p1);
            Assert.AreEqual(true, s1c != p1);
            Assert.AreEqual(true, s2 != p2);

            Assert.AreEqual(true, s3 != p1 && s3 != p2);
        }


        [TestMethod]
        public void TestHash_8()
        {
            HashTable hat = new HashTable(5, 3);

            Assert.AreEqual(true, hat.SeekSlot("word") >= 0);

            for (int i = 0; i < 5; i++)
                hat.Put("word");

            Assert.AreEqual(-1, hat.SeekSlot("word"));
            Assert.AreEqual(-1, hat.SeekSlot("whatever string"));
        }


        [TestMethod]
        public void TestHash_9()
        {
            HashTable hat = new HashTable(5, 3);

            Assert.AreEqual(-1, hat.Find("word"));

            hat.SeekSlot("word");

            Assert.AreEqual(-1, hat.Find("word"));

            hat.HashFun("word");

            Assert.AreEqual(hat.Put("word"), hat.Find("word"));
            
        }


        [TestMethod]
        public void TestHash_10()
        {
            HashTable hat = new HashTable(1, 3);

            int p1 = hat.Put("word");
            int p2 = hat.Put("ward");

            Assert.AreEqual(0, p1);
            Assert.AreEqual(-1, p2);
        }


        [TestMethod]
        public void TestHash_11()
        {
            HashTable hat = new HashTable(0, 3);

            int p1 = hat.Put("word");

            Assert.AreEqual(-1, p1);

        }


        [TestMethod]
        public void TestHash_A1()
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
        public void TestHash_A2()
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
        public void TestHash_A3()
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
        public void TestHashV2_1()
        {
            HashTable_1 hat = new HashTable_1(5, 16);

            int s1 = hat.Put(1);
            int s2 = hat.Put(2);

            Assert.AreEqual(false, s1 == s2);
        }


        [TestMethod]
        public void TestHashV2_2()
        {
            HashTable_1 hat = new HashTable_1(5, 16);

            int s1 = hat.Put(1);
            int s2 = hat.Put(1);

            Assert.AreEqual(false, s1 == s2);
        }


        [TestMethod]
        public void TestHashV2_3()
        {
            HashTable_1 hat = new HashTable_1(5, 16);

            int s1 = hat.Put(1);
            int s2 = hat.Put(1);
            int s3 = hat.Put(1);
            int s4 = hat.Put(1);
            int s5 = hat.Put(1);
            int s6 = hat.Put(1);

            Assert.AreEqual(false, s1 == s2);
            Assert.AreEqual(false, s1 == s3);
            Assert.AreEqual(false, s1 == s4);
            Assert.AreEqual(false, s1 == s5);
            Assert.AreEqual(false, s1 == s6);
            Assert.AreEqual(false, s2 == s3);
            Assert.AreEqual(false, s2 == s4);
            Assert.AreEqual(false, s2 == s5);
            Assert.AreEqual(false, s2 == s6);
            Assert.AreEqual(false, s3 == s2);
            Assert.AreEqual(false, s3 == s4);
            Assert.AreEqual(false, s3 == s5);
            Assert.AreEqual(false, s3 == s6);
            Assert.AreEqual(false, s4 == s3);
            Assert.AreEqual(false, s4 == s5);
            Assert.AreEqual(false, s4 == s6);
            Assert.AreEqual(false, s5 == s6);
        }


        [TestMethod]
        public void TestHashV2_4()
        {
            HashTable_1 hat = new HashTable_1(5, 16);
            Random r = new Random();
            int[] nxs = new int[hat.size];


            for (int i = 0; i < hat.size; i++)
                nxs[i] = hat.Put(r.Next(hat.size));


            for (int n = 0; n < nxs.Length; n++)
            {
                for (int n2 = 0; n2 < nxs.Length; n2++)
                    if (n != n2) Assert.AreEqual(true, nxs[0] != nxs[1]);
            }
        }
    }
}
