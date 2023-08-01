using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project1.Models
  
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int Id {get; set;    }
        [Required]
        [StringLength(20)]
        [Column("Invoice")]
        public string InvoiceNUmber { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [StringLength(100)]
        public string Customer { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}