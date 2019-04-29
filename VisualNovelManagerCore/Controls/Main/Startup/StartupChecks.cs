using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManagerCore.Services.Main.Startup;

namespace VisualNovelManagerCore.Controls.Main.Startup
{
    public class StartupChecks:IStartupChecks
    {
        public void RunStartupChecks()
        {
            CreateFolders();
        }

        private void CreateFolders()
        {
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\config");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\Database");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\vndb\images\characters");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\vndb\images\cover");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\vndb\images\screenshots");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\libs\");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\res\icons\country_flags");
        }
    }
}
