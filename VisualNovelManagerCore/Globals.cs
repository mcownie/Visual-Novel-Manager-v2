using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace VisualNovelManagerCore
{
    internal static class Globals
    {
        internal static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static uint VnId;
        internal static bool NsfwEnabled = false;
        internal static SpoilerLevel MaxSpoiler = SpoilerLevel.None;
    }

    internal enum SpoilerLevel
    {
        None,
        Minor,
        Major
    }
}
