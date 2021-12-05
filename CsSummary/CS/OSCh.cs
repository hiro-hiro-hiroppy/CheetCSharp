using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class OSCh
    {
        public class OSInfo
        { 
            /// <summary>
            /// OSのバージョン
            /// </summary>
            public string OS_Version { get; set; }
        
            public string OS_Product { get; set; }
            public string OS_Release { get; set; }
            public string OS_Build { get; set; }
            public string OS_Bit { get; set; }
            public string ProcessBit { get; set; }
            public string Framework_Version { get; set; }
            public string Registry_Framework_Version { get; set; }
            public string Registry_Framework_Release { get; set; }
            public string Host_Name { get; set; }
            public string Machine_Name { get; set; }
        }


        public OSInfo GetOSInfo()
        {
            OSInfo osInfo = new OSInfo();

            osInfo.OS_Version = Environment.OSVersion.VersionString;
            osInfo.OS_Product = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            osInfo.OS_Release = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId");

            osInfo.OS_Build = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild");
            osInfo.OS_Bit = Environment.Is64BitOperatingSystem ? "64 bit" : "32 bit";
            osInfo.ProcessBit = Environment.Is64BitProcess ? "64 bit" : "32 bit";
            osInfo.Framework_Version = Environment.Version.ToString();


            osInfo.Registry_Framework_Version = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Version");
            osInfo.Registry_Framework_Release = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Release");
            osInfo.Host_Name = Dns.GetHostName();
            osInfo.Machine_Name = Environment.MachineName;

            return osInfo;
        }




        private static string getRegistryValue(string keyname, string valuename)
        => Registry.GetValue(keyname, valuename, "").ToString();

    }
}
