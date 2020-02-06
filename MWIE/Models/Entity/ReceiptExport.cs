using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWIE.Models.Entity
{
    public class ReceiptExport
    {
        public int Id { get; set; }
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPay { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }
        
        public int? UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile ProUserProfilefile { get; set; }

        public virtual IEnumerable<DetailReceiptExport> DetailReceiptExports { get; set; }
    }
}