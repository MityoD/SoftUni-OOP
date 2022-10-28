using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
       
        public string Call(string number)
        {
            if (long.TryParse(number, out long result))
            {
                return $"Dialing... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
