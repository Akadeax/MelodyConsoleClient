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

                    client.cursorPos = new Vec2(Mathf.Clamp(posX, 0, Layer.WIDTH - 1), Mathf.Clamp(posY, 0, Layer.HEIGHT - 1));
                    break;

                case ConsoleKey.M:
                    Console.Write("[d (move all notes that are right of the cursor right)/a (move all notes that are right of the cursor left)]:");
                    ConsoleKey movDir = Console.ReadKey(false).Key;
                    Vec2 lastNote = client.SelectedLayer.grid.GetLastNotePos();
                    switch(movDir)
                    {
                        case ConsoleKey.D:
                            for(int x = lastNote.x; x > client.cursorPos.x; x--)
                            {
                                for(int y = 0; y < Layer.HEIGHT; y++)
                                {
                                    int currVal = client.SelectedLayer.grid.grid[x, y];
                                    if (currVal == 0) continue;
                                    client.SelectedLayer.grid.grid[x + 1, y] = currVal;
                                    client.SelectedLayer.grid.grid[x, y] = 0;
                                }
                            }
                            break;

                        case ConsoleKey.A:
                            for (int x = client.cursorPos.x + 1; x <= lastNote.x; x++)
                            {
                                for (int y = 0; y < Layer.HEIGHT; y++)
                                {
                                    Console.WriteLine($"{x}|{y}");
                                    int currVal = client.SelectedLayer.grid.grid[x, y];
                                    if (currVal == 0) continue;
                                    client.SelectedLayer.grid.grid[x - 1, y] = currVal;
                                    client.SelectedLayer.grid.grid[x, y] = 0;
                                }
                            }
                            break;

                        default:
                            return false;
                    }
                    
                    break;

                case ConsoleKey.Escape:
                    break;
            }
            return true;
        }
    }
}
