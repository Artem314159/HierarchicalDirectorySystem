using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Models
{
    public class HierarchyNodeModel
    {
        public string Name { get; set; }
        public string Href { get; set; }
        public List<HierarchyNodeModel> Children { get; set; } = new List<HierarchyNodeModel>();
    }
}