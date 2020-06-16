using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyConsoleClient
{
    class ViewCommand : Command
    {
        public ViewCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("View Operation [a (left)/d (right)/Esc (Exit)]: ");
            var sub = Console.ReadKey(false);
            Console.WriteLine();
            switch (sub.Key)
            {
                case ConsoleKey.A:
                    Console.Write("Move view left by: ");
                    if (!int.TryParse(Console.ReadLine(), out int lAmt)) return false;
                    client.pageStart -= lAmt;
                    break;

                case ConsoleKey.D:
                    Console.Write("Move view right by: ");
                    if (!int.TryParse(Console.ReadLine(), out int rAmt)) return false;
                    client.pageStart += rAmt;
                    break;

                case ConsoleKey.Escape:
                    break;
            }
            client.pageStart = Mathf.Clamp(client.pageStart, 0, Layer.WIDTH - Grid.SHOW_AMT);

            return true;
        }
    }
}
