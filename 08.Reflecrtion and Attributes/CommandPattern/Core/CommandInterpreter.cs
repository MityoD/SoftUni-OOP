using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string result = null;
            string[] commandArgs = args.Split();
            string commandName = commandArgs[0] + "Command";
            string[] parameters = commandArgs.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == commandName).FirstOrDefault();

            if (type == null)
            {   
                throw new InvalidOperationException("Invalid command");
            }

            //ICommand command = null;


            //if (commandName == nameof(HelloCommand))
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == nameof(ExitCommand))
            //{
            //    command = new ExitCommand();
            //}
            ICommand command = (ICommand)Activator.CreateInstance(type);
            result = command.Execute(parameters);
            return result;
        }
    }
}
