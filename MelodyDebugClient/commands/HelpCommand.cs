using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class HelpCommand : Command
    {
        public HelpCommand() : base(null) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Clear();
            Console.WriteLine("Commands:");
            Console.ReadKey();
            return true;
        }
    }
}
