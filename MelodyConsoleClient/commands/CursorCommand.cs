using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class CursorCommand : Command
    {
        public CursorCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Cursor Operation [s (set pos)/m (move)/Esc (Exit)]: ");
            var sub = Console.ReadKey(false);
            Console.WriteLine();
            switch (sub.Key)
            {
                case ConsoleKey.S:
                    Console.Write("Enter new X Pos: ");
                    if (!int.TryParse(Console.ReadLine(), out int posX)) return false;

                    Console.Write("Enter new Y Pos: ");
                    if (!int.TryParse(Console.ReadLine(), out int posY)) return false;

                    client.cursorPos = new Vec2(Math.Clamp(posX, 0, Layer.WIDTH - 1), Math.Clamp(posY, 0, Layer.HEIGHT - 1));
                    break;

                case ConsoleKey.M:
                    break;

                case ConsoleKey.Escape:
                    break;
            }
            return true;
        }
    }
}
