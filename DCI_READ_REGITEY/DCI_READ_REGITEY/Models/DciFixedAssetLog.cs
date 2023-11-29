using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DCI_READ_REGITEY.Models
{
    public partial class DciFixedAssetLog
    {
        public string ComputerName { get; set; }
        public int RegistryId { get; set; }
        public string RegistryKey { get; set; }
        public string RegistryValue { get; set; }
        public DateTime UpdateDt { get; set; }
    }
}
