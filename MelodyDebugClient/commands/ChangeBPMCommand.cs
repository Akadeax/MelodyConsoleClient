using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyConsoleClient
{
    class ChangeBPMCommand : Command
    {
        public ChangeBPMCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Enter new BPM: ");
            if(int.TryParse(Console.ReadLine(), out int newBPM))
            {
                client.currentBPM = newBPM;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
