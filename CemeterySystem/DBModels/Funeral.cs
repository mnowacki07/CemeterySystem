using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("Funerals")]
    public class Funeral
    {
        [Key]
        public Guid FuneralID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FuneralDate { get; set; }
        [Required]
        public Guid FuneralCompanyID { get; set; }
        [ForeignKey("FuneralCompanyID")]
        public FuneralCompany FuneralCompany { get; set; }
        [Required]
        public Guid CemeteryStaffPersonID { get; set; }
        [ForeignKey("CemeteryStaffPersonID")]
        public CemeteryStaffPerson CemeteryStaffPerson { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [NotMapped]
        public string FuneralShortDateFormatted
        {
            get
            {
                return this.FuneralDate.ToString(new System.Globalization.CultureInfo("pl-PL").DateTimeFormat.ShortDatePattern);
            }
        }
    }
}