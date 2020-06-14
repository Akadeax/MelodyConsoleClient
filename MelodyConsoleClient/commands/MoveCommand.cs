using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class MoveCommand : Command
    {
        public MoveCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            switch(pressed.Key)
            {
                case ConsoleKey.UpArrow:
                    client.cursorPos.y = Math.Clamp(--client.cursorPos.y, 0, Layer.HEIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    client.cursorPos.y = Math.Clamp(++client.cursorPos.y, 0, Layer.HEIGHT);
                    break;

                case ConsoleKey.LeftArrow:
                    client.cursorPos.x = Math.Clamp(--client.cursorPos.x, 0, Layer.HEIGHT);
                    break;
                case ConsoleKey.RightArrow:
                    client.cursorPos.x = Math.Clamp(++client.cursorPos.x, 0, Layer.HEIGHT);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
