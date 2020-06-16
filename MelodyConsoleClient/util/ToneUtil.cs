using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class ToneUtil
    {
        public static readonly (string, int)[] notes = new (string, int)[]
        {
            ("FS", 2), ("F", 2), ("E", 2), ("DS", 2), ("D", 2),
            ("CS", 2), ("C", 2), ("B", 1), ("AS", 1), ("A", 1),
            ("GS", 1), ("G", 1), ("FS", 1), ("F", 1), ("E", 1),
            ("DS", 1), ("D", 1), ("CS", 1), ("C", 1), ("B", 0),
            ("AS", 0), ("A", 0), ("GS", 0), ("G", 0), ("FS", 0)
        };
    }
}
