using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MelodyConsoleClient
{
    class ExportCommand : Command
    {
        public ExportCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Enter file path to write to: ");

            StringBuilder encoded = new StringBuilder();

            encoded.Append($"{client.currentName}/").Append($"{client.currentBPM}/");

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

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "*Melody File (*.melody)|*.melody",
                Title = "Save your Melody Project File"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = Path.GetFullPath(saveDialog.FileName);
                saveDialog.Dispose();

                if (!savePath.EndsWith("melody")) savePath += ".melody";

                File.WriteAllText(savePath, encoded.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        (string, int) HeightToNoteOctave(int yPos)
        {
            return ToneUtil.notes[yPos];
        }
    }
}
