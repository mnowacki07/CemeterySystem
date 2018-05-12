using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    public enum EnumBurialPlaceType
    {
        [Description("---")]            
        NULL = 0,        
        [Description("Typ 1")]
        TYPE1 = 1,
        [Description("Typ 2")]
        TYPE2 = 2            
    }

    public enum EnumBurialPlaceStatus
    {
        [Description("---")]
        NULL = 0,
        [Description("Status 1")]
        STATUS1 = 1,
        [Description("Status 2")]
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
        public Guid PaymentClassID { get; set; }
        [ForeignKey("PaymentClassID")]
        public PaymentClass PaymentClass { get; set; }
        public string Description { get; set; }
        [Required]
        public EnumBurialPlaceStatus Status { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [NotMapped]
        public string PaymentDateFormatted
        {
            get
            {
                try
                {
                    if (this.PaymentDate.HasValue)
                    {
                        return this.PaymentDate.Value.ToString(new System.Globalization.CultureInfo("pl-PL").DateTimeFormat.ShortDatePattern);
                    }
                }
                catch (Exception ex) { }
                return "";
            }
        }

        [NotMapped]
        public DateTime? FuturePaymentDate
        {
            get
            {
                if (this.PaymentClass != null && this.PaymentDate.HasValue)
                {
                    return this.PaymentDate.Value.AddDays(this.PaymentClass.ExtraDaysForPaymentMade);                    
                }
                return null;
            }
        }

        [NotMapped]
        public string FuturePaymentDateFormatted
        {
            get
            {
                try
                {
                    if (FuturePaymentDate.HasValue)
                    {
                        return this.FuturePaymentDate.Value.ToString(new System.Globalization.CultureInfo("pl-PL").DateTimeFormat.ShortDatePattern);
                    }
                }
                catch (Exception ex) { }
                return "";
            }
        }

        [NotMapped]
        public string PaymentClassNameFormatted
        {
            get
            {
                try
                {
                    if(this.PaymentClass != null)
                    {
                        return this.PaymentClass.Name + " - " + this.PaymentClass.PriceFormatted;
                    }
                }
                catch (Exception ex) { }
                return "";
            }
        }
    }
}