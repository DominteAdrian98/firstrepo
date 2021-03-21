using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Conference.Domain
{
    public partial class Speaker
    {
        [Key]
        public int ID { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string JobTitle { get; set; }
        public bool Active { get; set; }

        public virtual Workshop Workshop { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }
    }
}
