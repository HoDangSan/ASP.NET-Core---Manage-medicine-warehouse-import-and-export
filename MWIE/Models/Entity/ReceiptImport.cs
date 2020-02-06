using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWIE.Models.Entity
{
    public class ReceiptImport
    {
        public int Id { get; set; }
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public int? UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile ProUserProfilefile { get; set; }
        
        public virtual IEnumerable<DetailReceiptImport> DetailReceiptImports { get; set; }
        
    }
}