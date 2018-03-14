using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    public enum EnumGender
    {
        MALE = 0,
        FEMALE = 1
    }

    [Table("BurialPlaceBookers")]
    public class BurialPlaceBooker
    {
        [Key]
        public Guid BurialPlaceBookerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public EnumGender Gender { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public Guid BurialPlaceID { get; set; }
        [ForeignKey("BurialPlaceID")]
        public BurialPlace BurialPlace { get; set; }
    }
}