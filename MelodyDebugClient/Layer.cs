using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    public class Layer
    {
        private readonly Client client;
        public Layer(Client client)
        {
            this.client = client;
        }
        public const int WIDTH = 2000;
        public const int HEIGHT = 25;

        public Grid grid = new Grid(WIDTH, HEIGHT);
        

        public void PrintNoteGrid(Vec2 cursorPos)
        {
            string[] gridRows = grid.ToRowStrings(cursorPos, client.pageStart);
            for(int i = 0; i < gridRows.Length; i++)
            {
                string tone = ToneUtil.notes[i].Item1.PadRight(2);
                tone = tone.Replace('S', '#');
                gridRows[i] = $"{tone} | {gridRows[i]}";
            }
            
            foreach(string s in gridRows)
            {
                ColorPrint.WriteLineColored(s);
            }
        }
    }
}
