using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuHub.BOL
{
    [Table("Pages")]
    public partial class Page
    {
        public Page()
        {
            InverseParentNavigation = new HashSet<Page>();
        }

        public ulong PageId { get; set; }
        public string Guid { get; set; }
        public uint RingBinderId { get; set; }
        public ulong Parent { get; set; }
        public sbyte PageType { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public virtual Page ParentNavigation { get; set; }
        public virtual RingBinder RingBinder { get; set; }
        public virtual ICollection<Page> InverseParentNavigation { get; set; }
    }
}
