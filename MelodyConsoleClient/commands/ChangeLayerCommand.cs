using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class ChangeLayerCommand : Command
    {
        public ChangeLayerCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("[c (change)/a (add)/d (delete)/l (list): ");
            var sub = Console.ReadKey(true);
            Console.WriteLine();
            switch(sub.Key)
            {
                case ConsoleKey.C:
                    Console.Write("Enter the name of the layer: ");
                    string newSelection = Console.ReadLine();

                    if (!client.layers.ContainsKey(newSelection)) return false;

                    client.selectedLayer = newSelection;
                    break;

                case ConsoleKey.A:
                    Console.Write("Enter the name of the new layer: ");
                    string newLayerName = Console.ReadLine();

                    if (client.layers.ContainsKey(newLayerName)) return false;

                    client.layers.Add(newLayerName, new Layer());
                    break;

                case ConsoleKey.D:
                    Console.Write("Enter the name of the layer to delete: ");
                    string toDelete = Console.ReadLine();

                    if (!client.layers.ContainsKey(toDelete)) return false;

                    client.layers.Remove(toDelete);
                    break;

                case ConsoleKey.L:
                    Console.Clear();
                    foreach(string s in client.layers.Keys)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadKey();
                    break;

                case ConsoleKey.Escape:
                    break;
            }

            return true;
        }
    }
}
