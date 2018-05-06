using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public Guid ServiceID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal PriceGross { get; set; }        

        public string PriceGrossFormatted
        {
            get
            {
                return this.PriceGross.ToString("C", new System.Globalization.CultureInfo("pl-PL"));
            }
        }
    }
}