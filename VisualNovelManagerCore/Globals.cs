using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using LiteDB;

namespace VisualNovelManagerCore
{
    internal static class Globals
    {
        internal static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static uint VnId;
        internal static bool NsfwEnabled = false;
        internal static SpoilerLevel MaxSpoiler = SpoilerLevel.None;
        internal static LiteDatabase LiteDbInstance = new LiteDatabase(@"MyData.db");
    }

    internal enum SpoilerLevel
    {
        None,
        Minor,
        Major
    }
}
