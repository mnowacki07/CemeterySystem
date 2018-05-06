using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("BookedServices")]
    public class BookedService
    {
        [Key]
        public Guid BookedServiceID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal PriceGross { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public bool IsFinished { get; set; }

        [Required]
        public Guid BurialPlaceID { get; set; }
        [ForeignKey("BurialPlaceID")]
        public BurialPlace BurialPlace { get; set; }

        [Required]
        public Guid FamilyMemberID { get; set; }
        [ForeignKey("FamilyMemberID")]
        public FamilyMember FamilyMember { get; set; }

        public string PriceGrossFormatted
        {
            get
            {
                return this.PriceGross.ToString("C", new System.Globalization.CultureInfo("pl-PL"));
            }
        }
    }
}