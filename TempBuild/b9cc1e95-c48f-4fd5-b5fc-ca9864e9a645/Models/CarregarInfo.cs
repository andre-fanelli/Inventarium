using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Management;

namespace Inventarium.Models
{
    public class CarregarInfo
    {
        public static string ObterHostname()
        {
            return Environment.MachineName;
        }

        public static string ObterSO()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
            {
                foreach (var item in searcher.Get())
                {
                    return item["Caption"].ToString();
                }
            }
            return "Desconhecido";
        }

        public static string ObterProcessador()
        {
            using (var searcher = new ManagementObjectSearcher("select Name from Win32_Processor"))
            {
                foreach (var item in searcher.Get())
                {
                    return item["Name"].ToString();
                }
            }
            return "Desconhecido";
        }

        public static string ObterRAM()
        {
            ComputerInfo ci = new ();
            ulong memoriaTotal = ci.TotalPhysicalMemory;
            double memoriaGB = memoriaTotal / Math.Pow(1024, 3);

            return Math.Ceiling(memoriaGB).ToString("0");
        }

        public static string ObterStorage()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Size FROM Win32_LogicalDisk WHERE DeviceID = 'C:' AND DriveType = 3"))
            {
                foreach (var drive in searcher.Get())
                {
                    ulong size = (ulong)drive["Size"];
                    double sizeGB = size / Math.Pow(1024, 3);

                    return Math.Ceiling(sizeGB).ToString("0");
                }
            }
            return "Desconhecido";
        }

        public static string ObterFabricante()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem"))
            {
                foreach (var item in searcher.Get())
                {
                    return item["Manufacturer"]?.ToString();
                }
            }
            return "Desconhecido";
        }

        public static string ObterModelo()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem"))
            {
                foreach (var item in searcher.Get())
                {
                    return item["Model"]?.ToString();
                }
            }
            return "Desconhecido";
        }

        public static string ObterNumeroSerie()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
            {
                foreach (var item in searcher.Get())
                {
                    return item["SerialNumber"]?.ToString();
                }
            }
            return "Desconhecido";
        }
    }
}
