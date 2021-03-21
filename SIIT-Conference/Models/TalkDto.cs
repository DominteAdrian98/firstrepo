using Conference.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Models
{
    public class TalkDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        [MinLength(3)]
        public string Level { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Feedback Enabled")]
        public bool FeedbackEnabled { get; set; }

        [DisplayName("Speaker ID")]
        public int SpeakerId { get; set; }

      

    }
}
