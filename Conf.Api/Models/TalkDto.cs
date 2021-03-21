using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Api.Models
{
    public class TalkDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public bool Active { get; set; }
        public bool FeedbackEnabled { get; set; }

        public int SpeakerId { get; set; }
    }
}
