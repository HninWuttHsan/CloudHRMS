using System.Net;
using System.Net.Sockets;

namespace CloudHRMS.Utlitity
{
    public static class NetworkHelper
    {
        public static string GetIpAddress()
        {
            string ip = "127.0.0.1"; // nor local or public ip
            try
            {
                ip = new WebClient().DownloadString("http://icanhazip.com");// https://api.ipify.org/ or 175.156.157.139 //get public address
            }
            catch (Exception ex)
            {
                ip = GetLocalIp();// 192.168.xx.xx
            }
            return ip;
        }

        public static string GetLocalIp()
        {
            // get local Ip
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "we can't find local ip address";
        }
    }
}
