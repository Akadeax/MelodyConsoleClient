using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    public enum Instrument
    {
        Pause,
        Piano
    }

    public class InstrumentUtil
    {
        private static readonly Dictionary<Instrument, char> instrumentSymbols = new Dictionary<Instrument, char>()
        {
            { Instrument.Pause, '-' },
            { Instrument.Piano, '#' },
        };

        public static char GetSymbol(Instrument i)
        {
            return instrumentSymbols[i];
        }

        public static bool IsPlayable(Instrument instrument)
        {
            return ((int)instrument) >= 1;
        }


        private static readonly Dictionary<Instrument, string> instrumentNames = new Dictionary<Instrument, string>()
        {
            { Instrument.Pause, "PAUSE" },
            { Instrument.Piano, "PIANO" },
        };

        public static string GetInstrumentName(Instrument inst)
        {
            return instrumentNames[inst];
        }
    }
}
