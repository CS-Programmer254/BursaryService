using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Parent
    {
        public Guid ParentId { get; set; }

        [Required]
        public string FirstName{ get; set; }

        public string MiddleName{ get; set; }

        [Required]
        public string LastName{ get; set; }

        [Required]
        public string NationalIdentificationNumber{ get; set; }

        public string EmploymentStatus{ get; set; }

        [Required]
        public bool IsDisabled{ get; set; }

        [Required]
        public string RelationshipWithBursaryApplicant { get; set; }

        [Required]
        public string BursaryApplicantAdmissionNumber { get; set; }

        public Parent()
        {
            
        }

    }
}
