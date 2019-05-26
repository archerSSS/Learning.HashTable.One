using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Random r = new Random();
            int[] nums = new int[100];
            for (int i = 0; i < 100; i++)
            {
                nums[i] = r.Next(2);
            }
        }


    }
}
