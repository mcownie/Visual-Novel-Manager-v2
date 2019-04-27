using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace VisualNovelManagerCore
{
    public static class Globals
    {
        public static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static bool NsfwEnabled = false;
    }
}
