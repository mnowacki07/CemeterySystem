using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("PaymentClasses")]
    public class PaymentClass
    {
        [Key]
        public Guid PaymentClassID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}