using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Helper
{
    internal class ValidateExe
    {
        internal static bool ValidateExecutable(string FileName)
        {
            try
            {
                if (!File.Exists(FileName)) return false;
                byte[] twoBytes = new byte[2];
                using (FileStream fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fileStream.Read(twoBytes, 0, 2);
                }
                switch (Encoding.UTF8.GetString(twoBytes))
                {
                    case "MZ":
                        return true;
                    case "ZM":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
