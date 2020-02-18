using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class ReceiptImportViewModel
    {
        public int Id { get; set; }
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        
        public string IsActive { get; set; }

        public int? UserProfileId { get; set; }

        public string ProUserProfileName { get; set; }

        public virtual IEnumerable<DetailReceiptImport> DetailReceiptImports { get; set; }
    }
    
    public class ReceiptImportViewModelEdit 
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

    public class ImportDrugViewmodel
    {
        public string CodeReceipt { get; set; }
        public DateTime DateCreate { get; set; }
        public double TotalPrice { get; set; }
        
        public IEnumerable<DetailReceiptImportViewModel> DetailReceiptImportViewModels { get; set; }
    }
}