using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid CustomAddressID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }

        [NotMapped]
        public string AddressHtmlFormatted
        {
            get
            {
                return string.Join("<br/>", new string[] 
                {
                    Street + " " + HouseNumber + (!string.IsNullOrEmpty(FlatNumber) ? " / " + FlatNumber : ""),
                    Town,
                    PostCode
                }.Where(x => !string.IsNullOrEmpty(x)));
            }
        }
    }
}