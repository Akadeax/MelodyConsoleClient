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
        Bass_drum,
        Bass_guitar,
        Bell,
        Bit,
        Chime,
        Cow_bell,
        Didgeridoo,
        Flute,
        Guitar,
        Iron_xylophone,
        Banjo,
        Pling,
        Snare_drum,
        Sticks,
        Xylophone
    }

    public class InstrumentUtil
    {
        private static readonly Dictionary<Instrument, string> instrumentColorCodes = new Dictionary<Instrument, string>()
        {
            { Instrument.Pause, "&1" },
            { Instrument.Piano, "&2" },
            { Instrument.Bass_drum, "&3" },
            { Instrument.Bass_guitar, "&4" },
            { Instrument.Bell, "&5" },
            { Instrument.Bit, "&6" },
            { Instrument.Chime, "&7" },
            { Instrument.Cow_bell, "&8" },
            { Instrument.Didgeridoo, "&9" },
            { Instrument.Flute, "&10" },
            { Instrument.Guitar, "&11" },
            { Instrument.Iron_xylophone, "&12" },
            { Instrument.Banjo, "&13" },
            { Instrument.Pling, "&3" },
            { Instrument.Snare_drum, "&4" },
            { Instrument.Sticks, "&5" },
            { Instrument.Xylophone, "&6" },
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
            { Instrument.Bass_drum, "BASS_DRUM" },
            { Instrument.Bass_guitar, "BASS_GUITAR" },
            { Instrument.Bell, "BELL" },
            { Instrument.Bit, "BIT" },
            { Instrument.Chime, "CHIME" },
            { Instrument.Cow_bell, "COW_BELL" },
            { Instrument.Didgeridoo, "DIDGERIDOO" },
            { Instrument.Flute, "FLUTE" },
            { Instrument.Guitar, "GUITAR" },
            { Instrument.Iron_xylophone, "IRON_XYLOPHONE" },
            { Instrument.Banjo, "BANJO" },
            { Instrument.Pling, "PLING" },
            { Instrument.Snare_drum, "SNARE_DRUM" },
            { Instrument.Sticks, "STICKS" },
            { Instrument.Xylophone, "XYLOPHONE" },
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
