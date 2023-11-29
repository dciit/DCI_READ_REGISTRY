using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DCI_READ_REGITEY.Models
{
    public partial class DciFixedAssetSetting
    {
        public int RegistryId { get; set; }
        public string RegistryRoot { get; set; }
        public DateTime InsertDt { get; set; }
        public string InsertBy { get; set; }
        public int FixedStatus { get; set; }
    }
}
