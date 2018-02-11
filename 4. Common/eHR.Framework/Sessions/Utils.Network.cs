using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace eHR.Framework
{
	public partial class Utils
	{
        //Win32 API needed
        [DllImport("Iphlpapi.dll", EntryPoint = "SendARP")]
        internal extern static Int32 SendArp(Int32 destIpAddress, Int32 srcIpAddress,
        byte[] macAddress, ref Int32 macAddressLength);

        /// <summary>
        /// method for getting the MAC address of a remote computer
        /// NOTE: This only works on a local network computer that you have access to
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static PhysicalAddress GetMACFromNetworkComputer(IPAddress ipAddress)
        {
            try
            {
                //check what family the ip is from <cref="http://msdn.microsoft.com/en-us/library/system.net.sockets.addressfamily.aspx"/>
                if (ipAddress.AddressFamily != AddressFamily.InterNetwork)
                    throw new ArgumentException("The remote system only supports IPv4 addresses");

                //convert the IPAddress to an Int32
                Int32 convertedIp = ConvertIPToInt32(ipAddress);
                Int32 src = ConvertIPToInt32(ipAddress);
                //byte array
                byte[] macByteArray = new byte[6]; // 48 bit
                //set the length of the byte array
                int len = macByteArray.Length;
                //call the Win32 API SendArp <cref="http://msdn.microsoft.com/en-us/library/aa366358%28VS.85%29.aspx"/>
                int arpReply = SendArp(convertedIp, src, macByteArray, ref len);

                //check the reply, zero (0) is an error
                if (arpReply != 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                //return the MAC address in a PhysicalAddress format
                return new PhysicalAddress(macByteArray);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                System.Web.HttpContext.Current.Response.Write(ex.ToString());

                return null;
            }
        }

        private static Int32 ConvertIPToInt32(IPAddress apAddress)
        {
            byte[] bytes = apAddress.GetAddressBytes();
            return BitConverter.ToInt32(bytes, 0);
        }
	}
}
