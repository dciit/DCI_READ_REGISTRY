using DCI_READ_REGITEY.Contexts;
using DCI_READ_REGITEY.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_READ_REGITEY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var valuesBynames = new Dictionary<string, object>();
                List<DciFixedAssetSetting> listFixed = new List<DciFixedAssetSetting>();
                using (var db = new DBDCI())
                {
                    listFixed = db.DciFixedAssetSetting.Where(x => x.FixedStatus == 1).ToList();
                }
                foreach (DciFixedAssetSetting registry in listFixed)
                {
                    int registryId = registry.RegistryId;
                    string subkey = @"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName";
                    RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    string computerName = localKey.OpenSubKey(subkey).GetValue("ComputerName").ToString();
                    string REGISTRY_ROOT = $@"{registry.RegistryRoot}";
                    //Here I'm looking under LocalMachine. You can replace it with Registry.CurrentUser for current user...
                    using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(REGISTRY_ROOT))
                    {
                        if (rootKey != null)
                        {
                            string[] valueNames = rootKey.GetValueNames();
                            foreach (string currSubKey in valueNames)
                            {
                                object value = rootKey.GetValue(currSubKey);
                                valuesBynames.Add(currSubKey, value);
                                using (var db = new DBDCI())
                                {
                                    DciFixedAssetLog iLog = db.DciFixedAssetLog.FirstOrDefault(x => x.ComputerName == computerName && x.RegistryKey == currSubKey && x.RegistryId == registryId);
                                    if (iLog != null)
                                    {
                                        DciFixedAssetLog oLog = iLog;
                                        oLog.UpdateDt = DateTime.Now;
                                        oLog.RegistryValue = value.ToString();
                                        db.DciFixedAssetLog.Update(oLog);
                                       
                                    }
                                    else
                                    {
                                        DciFixedAssetLog nLog = new DciFixedAssetLog();
                                        nLog.ComputerName = computerName;
                                        nLog.UpdateDt = DateTime.Now;
                                        nLog.RegistryId = registryId;
                                        nLog.RegistryKey = currSubKey;
                                        nLog.RegistryValue = value.ToString();
                                        db.DciFixedAssetLog.Add(nLog);
                                    }
                                    db.SaveChanges();
                                }
                            }
                            rootKey.Close();
                        }
                    }
                }
                Console.Write("Press any key to close the Calculator console app...");
                Console.ReadKey();
                //string subkey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\WinSATAPI";
                //RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                //string value = localKey.OpenSubKey(subkey).GetValue("PrimaryAdapterString").ToString();

                //var valuesBynames = new Dictionary<string, object>();
                //const string REGISTRY_ROOT = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                ////Here I'm looking under LocalMachine. You can replace it with Registry.CurrentUser for current user...
                //using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(REGISTRY_ROOT))
                //{
                //    if (rootKey != null)
                //    {
                //        string[] valueNames = rootKey.GetValueNames();
                //        foreach (string currSubKey in valueNames)
                //        {
                //            object value = rootKey.GetValue(currSubKey);
                //            valuesBynames.Add(currSubKey, value);
                //        }
                //        rootKey.Close();
                //    }
                //}
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                Console.Write(ex.Message);
                Console.ReadKey();
                //react appropriately
            }
        }
    }
}
