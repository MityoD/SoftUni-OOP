using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    IPhone phone = new Smartphone();
                    Console.WriteLine(phone.Call(number));
                }
                else if (number.Length == 7)
                {
                    IPhone phone = new StationaryPhone();
                    Console.WriteLine(phone.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var url in websites)
            {
                ISmartphone phone = new Smartphone();
                Console.WriteLine(phone.Browse(url)); 
            }
        }
    }
}
