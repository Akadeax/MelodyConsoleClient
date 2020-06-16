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

        protected override bool OnCommand(ConsoleKeyInfo pressed)
        {
            ConsoleKey sub;
            if(!pressed.Modifiers.HasFlag(ConsoleModifiers.Control))
            {
                Console.Write("Project file [s (save)/l (load)/Esc (Exit)]: ");
                sub = Console.ReadKey(false).Key;
                Console.WriteLine();
            }
            else
            {
                sub = ConsoleKey.S;
            }

            switch (sub)
            {
                case ConsoleKey.S:
                    Console.Write("Save to file: ");
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "*Melody Project File (*.melodyproj)|*.melodyproj",
                        Title = "Save your Melody Project File"
                    };

                    if(saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = Path.GetFullPath(saveDialog.FileName);
                        saveDialog.Dispose();

                        if (!savePath.EndsWith("melodyproj")) savePath += ".melodyproj";

                        SaveLoadHandler.Save(savePath, client);
                        break;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.L:
                    Console.Write("Load file: ");
                    OpenFileDialog openDialog = new OpenFileDialog
                    {
                        Filter = "*Melody Project File (*.melodyproj)|*.melodyproj",
                        Title = "Open your Melody Project File"
                    };

                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        string openPath = Path.GetFullPath(openDialog.FileName);
                        openDialog.Dispose();

                        if (!openPath.EndsWith("melodyproj")) openPath += ".melodyproj";

                        SaveLoadHandler.Load(openPath).Start();
                        Environment.Exit(0);
                        break;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.Escape:
                    break;
            }

            return true;
        }
    }
}
