using System.ComponentModel.DataAnnotations.Schema;

namespace MWIE.Models.Entity
{
    public class DetailReceiptImport
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug Drug { get; set; }

        public int? ReceiptImportId { get; set; }
        [ForeignKey("ReceiptImportId")]
        public ReceiptImport ReceiptImport { get; set; }
    }
}