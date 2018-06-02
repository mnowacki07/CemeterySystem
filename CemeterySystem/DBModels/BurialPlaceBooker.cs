using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace CemeterySystem.DBModels
{
    public enum EnumGender
    {
        [Description("Mężczyzna")]
        MALE = 0,
        [Description("Kobieta")]
        FEMALE = 1
    }

    [Table("BurialPlaceBookers")]
    public class BurialPlaceBooker
    {
        [Key]
        public Guid BurialPlaceBookerID { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        public EnumGender? Gender { get; set; }
        public string PESEL { get; set; }
        public Guid BurialPlaceID { get; set; }
        [ForeignKey("BurialPlaceID")]
        public BurialPlace BurialPlace { get; set; }
        public Guid? FamilyMemberID { get; set; }
        [ForeignKey("FamilyMemberID")]
        public FamilyMember FamilyMember { get; set; }
    }
}