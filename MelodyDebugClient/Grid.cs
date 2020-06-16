using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    public class Grid
    {
        public int[,] grid;

        private readonly int WIDTH, HEIGHT;
        public const int SHOW_AMT = 50;

        public Grid(int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            if (grid == null)
            {
                grid = new int[WIDTH, HEIGHT];
            }
        }

        public string[] ToRowStrings(Vec2 cursorPos, int pageStart)
        {
            string[] output = new string[HEIGHT];
            for (int x = pageStart; x < pageStart + SHOW_AMT; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (cursorPos.x == x && cursorPos.y == y)
                    {
                        output[y] += "&11+ ";
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

        public Vec2 GetLastNotePos()
        {
            for (int x = WIDTH - 1; x >= 0; x--)
            {
                for (int y = HEIGHT - 1; y >= 0; y--)
                {
                    if (grid[x, y] != 0) return new Vec2(x, y);
                }
            }
            return Vec2.Zero;
        }
    }
}
