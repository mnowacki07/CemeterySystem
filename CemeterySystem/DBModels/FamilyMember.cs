using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("FamilyMembers")]
    public class FamilyMember
    {
        [Key]
        public Guid FamilyMemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public Guid AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
        [Required]
        public Guid DeadPersonID { get; set; }
        [ForeignKey("DeadPersonID")]
        public DeadPerson DeadPerson { get; set; }
    }
}