using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class DrugViewModel
    {
        public DrugViewModel(int? producerId, int? groupDrugId)
        {
            ProducerId = producerId;
            GroupDrugId = groupDrugId;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpriryDate { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }

        public int? ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        public string ProducerName { get; set; }

        public int? GroupDrugId { get; set; }
        [ForeignKey("GroupDrugId")]
        public GroupDrug GroupDrug { get; set; }

        public string GroupDrugName { get; set; }
    }
    
    public class DrugViewModelEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpriryDate { get; set; }
        public bool IsActive { get; set; }
        public int ProducerId { get; set; }
        public int GroupDrugId { get; set; }
    }

}