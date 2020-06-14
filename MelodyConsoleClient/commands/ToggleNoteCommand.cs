using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    class ToggleNoteCommand : Command
    {
        public ToggleNoteCommand(Client client) : base(client) { }

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            int instrument = client.selectedInstrument;
            int valueAtCursor = client.SelectedLayer.grid.GetValue(client.cursorPos);

            int newVal = valueAtCursor == 0 ? instrument : 0;
            client.SelectedLayer.grid.SetValue(client.cursorPos, newVal);
            return true;
        }
    }
}
