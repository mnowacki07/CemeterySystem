using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("FuneralCompanies")]
    public class FuneralCompany
    {
        [Key]
        public Guid FuneralCompanyID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public Guid AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
    }
}