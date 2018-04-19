using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("DeadPersons")]
    public class DeadPerson
    {
        [Key]
        public Guid DeadPersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PESEL { get; set; }
        [Required]
        public EnumGender Gender { get; set; }
        [Required]
        public Guid BurialPlaceID { get; set; }
        [ForeignKey("BurialPlaceID")]
        public BurialPlace BurialPlace { get; set; }
        public Guid FuneralID { get; set; }
        [ForeignKey("FuneralID")]
        public Funeral Funeral { get; set; }
        public Guid? FamilyMemberID { get; set; }
        [ForeignKey("FamilyMemberID")]
        public FamilyMember FamilyMember { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}