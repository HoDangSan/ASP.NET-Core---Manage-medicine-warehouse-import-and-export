using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class ReceiptLiquidationViewModel
    {
        public int Id { get; set; }
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }
        
        public int? UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile ProUserProfilefile { get; set; }

        public virtual IEnumerable<DetailReceiptLiquidation> DetailReceiptLiquidations { get; set; }
    }
    
    public class ReceiptLiquidationViewModelEdit
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

        public virtual IEnumerable<DetailReceiptLiquidation> DetailReceiptLiquidations { get; set; }
    }
}