using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class HashTable_1
    {
        public int size;
        public int step;
        public int[] slots;
        public Random random = new Random();
        public HashFunctionSelector hfs;

        public HashTable_1(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new int[size];
            hfs = new HashFunctionSelector(sz);
            for (int i = 0; i < size; i++) slots[i] = 0;
        }

        public int HashFun(int value)
        {
            return hfs.RandomHashFun(value);
            return 0;
        }

        public int SeekSlot(int value)
        {
            int nx = HashFun(value);

            for (int i = 0; i < size; i++)
            {
                if (slots[nx] == 0) return nx;
                else nx += step;
                if (nx >= size) nx = nx % size;
            }
            return -1;
        }

        public int Put(int value)
        {
            int nx = SeekSlot(value);
            if (nx == -1) return -1;
            slots[nx] = value;
            return nx;
        }

        public int Find(int value)
        {
            for (int i = 0; i < size; i++)
                if (slots[i] == value) return i;
            return -1;
        }
    }


    // Класс случайно подбирающий хэш-функцию
    //
    public class HashFunctionSelector
    {

        private Random r;
        private int size;
        private int p;

        public HashFunctionSelector(int size)
        {
            r = new Random();
            this.size = size;
            p = size * 3;
        }

        public int HashFun_1(int value)
        {
            return (((r.Next(p - 1) + 1) * value + (r.Next(p) - 1)) % p) % size;
        }

        public int HashFun_2(int value)
        {
            return (((r.Next(p - 1) + 1) * value + (r.Next(p) - 1)) % p) % size;
        }

        public int HashFun_3(int value)
        {
            return (((r.Next(p - 1) + 1) * value + (r.Next(p) - 1)) % p) % size;
        }

        public int RandomHashFun(int value)
        {
            int hf = r.Next(3);
            if (hf == 0) return HashFun_1(value);
            if (hf == 1) return HashFun_2(value);
            if (hf == 2) return HashFun_3(value);
            return HashFun_1(value);
        }
    }
}