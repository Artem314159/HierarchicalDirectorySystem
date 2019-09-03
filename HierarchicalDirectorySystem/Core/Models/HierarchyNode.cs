using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Core.Models
{
    public class HierarchyNode : NamedEntity
    {
        public int? ParentId { get; set; }
    }
}