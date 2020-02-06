using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class ReceiptExportViewModel
    {
        public int Id { get; set; }
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        public string IsPay { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }
        
        public int? UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile ProUserProfilefile { get; set; }

        public virtual IEnumerable<DetailReceiptExport> DetailReceiptExports { get; set; }
    }
    
    public class ReceiptExportViewModelEdit
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
    
    public class ReceiptExportCreate
    {
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPay { get; set; }
        public bool IsActive { get; set; }
        
        public int UserProfileId { get; set; }
        public virtual IEnumerable<DetailReceiptExportCreate> DetailReceiptExportCreates { get; set; }
    }
    
    public class DetailReceiptExportCreate
    {
        public int Amount { get; set; }
        public int AmountRemaining { get; set; }
        public double TotalPrice { get; set; }
        public int DrugId { get; set; }
    }
}