using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Models.efdemo.Dto
{
    public class BaseDto
    {
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
