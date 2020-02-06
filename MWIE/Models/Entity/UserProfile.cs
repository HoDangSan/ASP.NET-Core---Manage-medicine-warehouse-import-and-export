using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace MWIE.Models.Entity
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        [EmailAddress] 
        public string Email { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public IEnumerable<ReceiptImport> ReceiptImports { get; set; }
        public IEnumerable<ReceiptExport> ReceiptExports { get; set; }
        public IEnumerable<ReceiptLiquidation> ReceiptLiquidations { get; set; }
    }
}