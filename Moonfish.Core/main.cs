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
            GuerillaCs ripper = new GuerillaCs( @"C:\Program Files (x86)\Microsoft Games\Halo 2 Map Editor\H2Guerilla.exe" );
            
            ripper.DumpTagLayout( @"C:\Users\stem\Documents\moonfish\moonfish\Moonfish.Core\Guerilla\Tags", "vehi", "" );
            ripper.DumpTagLayout( @"C:\Users\stem\Documents\moonfish\moonfish\Moonfish.Core\Guerilla\Tags", "bipd", "" );
            ripper.DumpTagLayout( @"C:\Users\stem\Documents\moonfish\moonfish\Moonfish.Core\Guerilla\Tags", "unit", "" );
            return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
