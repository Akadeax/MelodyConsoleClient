using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MelodyConsoleClient
{
    public class Client
    {
        [STAThread]
        static void Main()
        {
            new Client().Start();
        }

        public int selectedInstrument = 1;

        public string currentName = "project";
        public int currentBPM = 300;

        public Vec2 cursorPos = new Vec2();

        public int pageStart = 0;

        public Dictionary<string, Layer> layers = new Dictionary<string, Layer>();

        public string selectedLayer = "default";

        [JsonIgnore]
        public Layer SelectedLayer
        {
            get
            {
                return layers[selectedLayer];
            }
        }

        [JsonIgnore]
        readonly Dictionary<ConsoleKey, Command> commands;

        public Client()
        {
            layers.Add("default", new Layer(this));

            MoveCommand moveCommand = new MoveCommand(this);
            commands = new Dictionary<ConsoleKey, Command>()
            {
                { ConsoleKey.UpArrow, moveCommand },
                { ConsoleKey.DownArrow, moveCommand },
                { ConsoleKey.LeftArrow, moveCommand },
                { ConsoleKey.RightArrow, moveCommand },

                { ConsoleKey.Spacebar, new ToggleNoteCommand(this) },
                { ConsoleKey.L, new LayerCommand(this) },
                { ConsoleKey.E, new ExportCommand(this) },
                { ConsoleKey.I, new InstrumentCommand(this) },
                { ConsoleKey.C, new CursorCommand(this) },
                { ConsoleKey.S, new SaveLoadCommand(this) },
                { ConsoleKey.N, new ChangeNameCommand(this) },
                { ConsoleKey.B, new ChangeBPMCommand(this) },
                { ConsoleKey.V, new ViewCommand(this) },

                { ConsoleKey.H, new HelpCommand() },
            };
        }

        public void Start()
        {

            while (true)
            {
                Console.Clear();

                string topLine = 
                    $@"
Name: {currentName} | 
Cursor: ({cursorPos.x}/{cursorPos.y}) | 
Instrument: {InstrumentUtil.GetInstrumentName((Instrument)selectedInstrument)} | 
Current Layer: {selectedLayer} | 
BPM: {currentBPM} | 
Scroll: {pageStart}
                    ".Replace(Environment.NewLine, "");
                Console.WriteLine(topLine);
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
