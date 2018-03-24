using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CemeterySystem.DBModels
{
    [Table("CemeteryStaffPersons")]
    public class CemeteryStaffPerson
    {
        [Key]
        public Guid CemeteryStaffPersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}