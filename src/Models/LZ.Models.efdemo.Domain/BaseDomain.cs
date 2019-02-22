using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Models.efdemo.Domain
{
    public class BaseDomain
    {
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
