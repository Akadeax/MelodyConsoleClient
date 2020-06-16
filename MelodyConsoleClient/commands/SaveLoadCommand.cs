using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MelodyConsoleClient
{
    class SaveLoadCommand : Command
    {
        public SaveLoadCommand(Client client) : base(client) { }

        [STAThread]
        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            Console.Write("Project file [s (save)/l (load)/Esc (Exit)]: ");
            var sub = Console.ReadKey(false);
            Console.WriteLine();
            switch (sub.Key)
            {
                case ConsoleKey.S:
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.OpenFile();
                    Console.Write("Save to path: ");

                    string savePath = Console.ReadLine();
                    if (!savePath.EndsWith("melodyproj")) savePath += ".melodyproj";

                    SaveLoadHandler.Save(savePath, client);
                    break;

                case ConsoleKey.L:
                    Console.Write("Load from path: ");

                    string loadPath = Console.ReadLine();
                    if (!loadPath.EndsWith("melodyproj")) loadPath += ".melodyproj";
                    if (!File.Exists(loadPath)) return false;

                    SaveLoadHandler.Load(loadPath).Start();
                    Environment.Exit(0);
                    break;

                case ConsoleKey.Escape:
                    break;
            }

            return true;
        }
    }
}
