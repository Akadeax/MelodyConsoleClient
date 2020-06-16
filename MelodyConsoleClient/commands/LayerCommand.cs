using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelodyConsoleClient
{
    class LayerCommand : Command
    {
        public LayerCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Layer [c (change)/a (add)/d (delete)/l (list)/Esc (Exit)]: ");
            var sub = Console.ReadKey(false);
            Console.WriteLine();
            switch(sub.Key)
            {
                case ConsoleKey.C:
                    Console.Write("Enter the name of the layer: ");
                    string newSelection = Console.ReadLine().ToLower();

                    if (!client.layers.ContainsKey(newSelection)) return false;

                    client.selectedLayer = newSelection;
                    break;

                case ConsoleKey.A:
                    Console.Write("Enter the name of the new layer: ");
                    string newLayerName = Console.ReadLine().ToLower();

                    // if layer already exists
                    if (client.layers.ContainsKey(newLayerName)) return false;

                    client.layers.Add(newLayerName, new Layer());
                    break;

                case ConsoleKey.D:
                    Console.Write("Enter the name of the layer to delete: ");
                    string toDelete = Console.ReadLine().ToLower();

                    // if layer to delete doesn't exist/is last layer
                    if (!client.layers.ContainsKey(toDelete)) return false;
                    if (client.layers.Count <= 1) return false;

                    // reset to default layer if client is deleting the layer they're currently on
                    if (client.selectedLayer == toDelete) client.selectedLayer = client.layers.First().Key;

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
