using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Helper
{
    internal class ConnectionTest
    {
        internal static bool VndbTcpSocketTest()
        {
            try
            {
                TcpClient client = new TcpClient("api.vndb.org", 19535);
                client.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
