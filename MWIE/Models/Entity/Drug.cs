using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWIE.Models.Entity
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpriryDate { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public int? ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        public int? GroupDrugId { get; set; }
        [ForeignKey("GroupDrugId")]
        public GroupDrug GroupDrug { get; set; }
    }
}