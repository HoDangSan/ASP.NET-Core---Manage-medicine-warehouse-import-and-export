using System.ComponentModel.DataAnnotations.Schema;

namespace MWIE.Models.Entity
{
    public class DetailReceiptExport
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int AmountRemaining { get; set; }
        public double TotalPrice { get; set; }

        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug Drug { get; set; }
        
        public int? ReceiptExportId { get; set; }
        [ForeignKey("ReceiptExportId")]
        public ReceiptExport ReceiptExport { get; set; }
    }
}