using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain
{
    public partial class Workshop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PlacesAvailable { get; set; }
        public string RegistrationLink { get; set; }
        public bool Active { get; set; }
        public bool RegistrationOpened { get; set; }
        public string Prerequisites { get; set; }
        public string ShortDescription { get; set; }

        public virtual ICollection<Speaker> Speakers { get; set; }
    }
}
