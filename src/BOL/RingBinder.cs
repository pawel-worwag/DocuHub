using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuHub.BOL
{
    [Table("RingBinders")]
    public partial class RingBinder
    {
        public RingBinder()
        {
            Pages = new HashSet<Page>();
        }

        public uint RingBinderId { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pinned { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Page> Pages { get; set; }
    }
}
