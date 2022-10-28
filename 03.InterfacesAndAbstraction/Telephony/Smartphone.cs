using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IPhone, ISmartphone
    {
        public string Browse(string website)
        {
            bool isInvalid = false;
            foreach (var @char in website)
            {
                if (char.IsDigit(@char))
                {
                    isInvalid = true;
                    break;
                }
            }
            if (isInvalid)
            {   
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {website}!";
            }
        }

        public string Call(string number)
        {
            if (long.TryParse(number, out long result))
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
