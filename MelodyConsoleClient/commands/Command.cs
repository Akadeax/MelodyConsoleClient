using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MelodyConsoleClient
{
    abstract class Command
    {
        protected Client client;
        public Command(Client client)
        {
            this.client = client;
        }
        public void RunCommand(ConsoleKeyInfo pressed)
        {
            if(!OnCommand(pressed))
            {
                Console.Clear();
                Console.WriteLine("Invalid input!");
                Thread.Sleep(500);
            }
        }

        protected abstract bool OnCommand(ConsoleKeyInfo pressed);
    }
}
