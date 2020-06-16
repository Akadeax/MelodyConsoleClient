using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyConsoleClient
{
    public static class Mathf
    {
        public static int Clamp(int toClamp, int min, int max)
        {
            return Math.Max(Math.Min(toClamp, max), min);
        }
    }
}
