using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    public class Grid
    {
        public int[,] grid;

        private readonly int WIDTH, HEIGHT;
        public Grid(int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            if (grid == null)
            {
                grid = new int[WIDTH, HEIGHT];
            }
        }

        public string[] ToRowStrings(Vec2 cursorPos)
        {
            string[] output = new string[HEIGHT];
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (cursorPos.x == x && cursorPos.y == y)
                    {
                        output[y] += "+ ";
                    }
                    else if (grid[x,y] == (int)Instrument.Pause)
                    {
                        output[y] += "- ";
                    }
                    else
                    {
                        output[y] += InstrumentUtil.GetColorCode((Instrument)grid[x,y]) + "# ";
                    }
                }
            }
            return output;
        }

        public void SetValue(Vec2 pos, int val)
        {
            grid[pos.x,pos.y] = val;
        }
        public int GetValue(Vec2 pos)
        {
            return grid[pos.x,pos.y];
        }
    }
}
