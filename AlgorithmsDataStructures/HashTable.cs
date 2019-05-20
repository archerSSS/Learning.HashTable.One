using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int nx = 0;
            char[] chars = value.ToCharArray();
            for (int i = 0; i < value.Length-1; i++)
                nx += Convert.ToInt32(chars[i]);
            
            nx = nx % size;
            return nx;
            return 0;
        }

        public int SeekSlot(string value)
        {
            int nx = HashFun(value);

            for (int i = 0; i < size; i++)
            {
                if (slots[nx] == null) return nx;
                else nx += step;
                if (nx >= size) nx = nx % size; 
            }
                
            return -1;
        }

        public int Put(string value)
        {
            int nx = SeekSlot(value);
            if (nx == -1) return -1;
            slots[nx] = value;
            return nx;
        }

        public int Find(string value)
        {
            for (int i = 0; i < size; i++)
                if (slots[i] == value) return i;
            return -1;
        }
    }
}