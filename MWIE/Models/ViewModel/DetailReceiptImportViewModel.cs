using System;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class DetailReceiptImportViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public string DrugName { get; set; }
        public int? ReceiptImportId { get; set; }
        public double Price { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpriryDate { get; set; }
    }
    
}