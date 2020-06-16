using System;
using System.Globalization;
using System.Linq;

namespace MelodyConsoleClient
{
    class InstrumentCommand : Command
    {
        public InstrumentCommand(Client client) : base(client) { }

        private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Instrument [c (change)/Esc (Exit)]: ");
            var sub = Console.ReadKey(false);
            Console.WriteLine();
            switch (sub.Key)
            {
                case ConsoleKey.C:
                    Console.Clear();
                    Console.WriteLine("Enter new instrument name:");
                    foreach(string s in InstrumentUtil.GetInstrumentNames().Skip(1))
                    {
                        Console.Write($"{textInfo.ToTitleCase(s.ToLower())}, ");
                        Console.WriteLine();
                    }

                    string newInstrument = Console.ReadLine().ToUpper();
                    // if newInstrument is not actually a valid instrument
                    if(!InstrumentUtil.instrumentNames.Reverse.ContainsKey(newInstrument))
                    {
                        return false;
                    }
                    client.selectedInstrument = (int)InstrumentUtil.instrumentNames.Reverse[newInstrument];
                    break;
                case ConsoleKey.Escape:
                    break;
            }

            return true;
        }
    }
}
