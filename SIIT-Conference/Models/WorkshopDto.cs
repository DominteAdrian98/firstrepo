using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Models
{
    public class WorkshopDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Places Available")]
        public int? PlacesAvailable { get; set; }
        [Required]
        [Display(Name = "Registration Link")]
        public string RegistrationLink { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Registration Opened")]
        public bool RegistrationOpened { get; set; }
        [Required]
        [MinLength(3)]
        public string Prerequisites { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
    }
}
