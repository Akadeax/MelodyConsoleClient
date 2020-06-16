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
                    client.cursorPos.y = Mathf.Clamp(--client.cursorPos.y, 0, Layer.HEIGHT - 1);
                    break;
                case ConsoleKey.DownArrow:
                    client.cursorPos.y = Mathf.Clamp(++client.cursorPos.y, 0, Layer.HEIGHT - 1);
                    break;

                case ConsoleKey.LeftArrow:
                    client.cursorPos.x = Mathf.Clamp(--client.cursorPos.x, 0, Layer.WIDTH - 1);
                    break;
                case ConsoleKey.RightArrow:
                    client.cursorPos.x = Mathf.Clamp(++client.cursorPos.x, 0, Layer.WIDTH - 1);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
