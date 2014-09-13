using Moonfish.Debug;
using Moonfish.Graphics;
using Moonfish.Guerilla;
using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Moonfish
{
    static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GuerillaToEnt ripper = new GuerillaToEnt();
            //foreach (var tag in ripper.DumpTagLayout(@"C:\Program Files (x86)\Microsoft Games\Halo 2 Map Editor\H2Guerilla.exe", @"C:\Users\stem\Documents\h2pc to h2xbox", ""))
            //{
            //    Console.WriteLine("Generated {0}", tag.Name);
            //    Validator validator = new Validator();
            //    validator.Validate(tag, ripper.h2Tags);
            //    Console.WriteLine("Validated {0}", tag.Name);
            //}
            //return;
            //MapStream map = new MapStream(@"C:\Users\stem\Documents\modding\sharedx.map");

            //Weapon test = map["weap", @"flag"].Deserialize();
            //test.hierarchyModel.ToString();
            //return;
            //GuerillaCs ripper = new GuerillaCs(@"C:\Program Files (x86)\Microsoft Games\Halo 2 Map Editor\H2Guerilla.exe");
            //ripper.DumpTagLayout(@"C:\Users\stem\Documents\h2pc to h2xbox", "scnr", "Scenario");
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
