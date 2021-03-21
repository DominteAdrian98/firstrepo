using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Api.Models
{
    public class SpeakerDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string JobTitle { get; set; }
        public bool Active { get; set; }
    }
}
