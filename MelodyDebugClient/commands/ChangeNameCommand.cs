using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyConsoleClient
{
    class ChangeNameCommand : Command
    {
        public ChangeNameCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Enter new Name: ");
            client.currentName = Console.ReadLine();
            return true;
        }
    }
}
