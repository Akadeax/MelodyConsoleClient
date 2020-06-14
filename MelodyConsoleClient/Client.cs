using System;
using System.Collections.Generic;

namespace MelodyConsoleClient
{
    class Client
    {
        static void Main()
            => new Client().Start();

        public int selectedInstrument = 1;

        public Vec2 cursorPos = new Vec2();

        public SortedDictionary<string, Layer> layers = new SortedDictionary<string, Layer>();
        public string selectedLayer = "default";

        public Layer SelectedLayer
        {
            get
            {
                return layers[selectedLayer];
            }
        }

        readonly Dictionary<ConsoleKey, Command> commands;

        Client()
        {
            layers.Add("default", new Layer());

            MoveCommand moveCommand = new MoveCommand(this);
            commands = new Dictionary<ConsoleKey, Command>()
            {
                { ConsoleKey.UpArrow, moveCommand },
                { ConsoleKey.DownArrow, moveCommand },
                { ConsoleKey.LeftArrow, moveCommand },
                { ConsoleKey.RightArrow, moveCommand },

                { ConsoleKey.Spacebar, new ToggleNoteCommand(this) },
                { ConsoleKey.L, new ChangeLayerCommand(this) },
                { ConsoleKey.E, new ExportCommand(this) },
            };
        }

        void Start()
        {

            while (true)
            {
                Console.Clear();
                SelectedLayer.PrintNoteGrid(cursorPos);
                var key = Console.ReadKey(true);

                if (commands.ContainsKey(key.Key))
                {
                    commands[key.Key].RunCommand(key);
                }
            }
        }
    }
}
