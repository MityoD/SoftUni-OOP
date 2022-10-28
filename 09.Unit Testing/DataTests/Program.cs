using System;
using System.Linq;

namespace DataTests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            foreach (var item in testArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
