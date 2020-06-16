using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelodyConsoleClient
{
    public enum Instrument
    {
        Pause,
        Piano,
        Bell
    }

    public class InstrumentUtil
    {
        private static readonly Dictionary<Instrument, string> instrumentColorCodes = new Dictionary<Instrument, string>()
        {
            { Instrument.Pause, "&1" },
            { Instrument.Piano, "&2" },
            { Instrument.Bell, "&3" },
        };

        public static string GetColorCode(Instrument i)
        {
            return instrumentColorCodes[i];
        }

        public static bool IsPlayable(Instrument instrument)
        {
            return ((int)instrument) >= 1;
        }

        public static readonly BiMap<Instrument, string> instrumentNames = new BiMap<Instrument, string>()
        {
            { Instrument.Pause, "PAUSE" },
            { Instrument.Piano, "PIANO" },
            { Instrument.Bell, "BELL" },
        };

        public static string GetInstrumentName(Instrument inst)
        {
            return instrumentNames.Forward[inst];
        }

        public static string[] GetInstrumentNames()
        {
            return instrumentNames.Forward.Values;
        }

    }
}
