using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Models
{
    public class SpeakerDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [MinLength(3)]
        public string Company { get; set; }
        [Required]
        [MinLength(3)]
        public string WebSite { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public bool Active { get; set; }
    }
}
