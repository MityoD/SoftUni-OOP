using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class BeepCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.Beep(1000, 700);
            return "Beep" + string.Join(" ", args);
        }
    }
}
