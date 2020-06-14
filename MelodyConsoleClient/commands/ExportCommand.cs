using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MelodyConsoleClient
{
    class ExportCommand : Command
    {
        public ExportCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Enter file path to write to: ");
            string path = Console.ReadLine();
            StringBuilder encoded = new StringBuilder();

            encoded.Append("testName/").Append("300/");

            for(int x = 0; x < Layer.WIDTH; x++)
            {
                for(int y = 0; y < Layer.HEIGHT; y++)
                {
                    foreach(Layer layer in client.layers.Values)
                    {
                        (string tone, int currOct) = HeightToNoteOctave(y);
                        int currVal = layer.grid.GetValue(new Vec2(x, y));
                        if (currVal != 0)
                        {
                            encoded.Append($"{InstrumentUtil.GetInstrumentName((Instrument)currVal)},{tone},{currOct};");
                        }
                    }
                }
                encoded.Length -= 1;
                encoded.Append("/");
            }
            encoded.Length -= 1;

            File.WriteAllText(path, encoded.ToString());
            return true;
        }

        (string, int) HeightToNoteOctave(int yPos)
        {
            return ToneUtil.notes[yPos];
        }
    }
}
