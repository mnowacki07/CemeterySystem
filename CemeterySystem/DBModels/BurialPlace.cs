using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    public enum EnumBurialPlaceType
    {
        // null has to stay as a null value in db
        NULL = 0,
        // define some types:
        TYPE1 = 1,
        TYPE2 = 2            
    }

    public enum EnumBurialPlacePaymentClass
    {
        NULL = 0,
        CLASS1 = 1,
        CLASS2 = 2
    }

    public enum EnumBurialPlaceStatus
    {
        NULL = 0,
        STATUS1 = 1,
        STATUS2 = 2
    }

    [Table("BurialPlaces")]
    public class BurialPlace
    {
        [Key]
        public Guid BurialPlaceID { get; set; }
        [Required]
        public string FieldNumber { get; set; }        
        public string GraveNumber { get; set; }  
        [Required]
        public EnumBurialPlaceType Type { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? PaymentDate { get; set; }
        [Required]
        public EnumBurialPlacePaymentClass PaymentClass { get; set; }
        public string Description { get; set; }
        [Required]
        public EnumBurialPlaceStatus Status { get; set; }
    }
}