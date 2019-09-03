using HierarchicalDirectorySystem.Core.Context;
using HierarchicalDirectorySystem.Core.Models;
using HierarchicalDirectorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Services
{
    public class NodesService : ServiceBase
    {
        public NodesService(DirectorySystemContext db) : base(db)
        { }

        public HierarchyNodeModel GetNode(string path)
        {
            var hierarchyNodes = db.HierarchyNodes.ToList();
            var parent = hierarchyNodes.FirstOrDefault(_ => _.ParentId == null);
            if (parent == null) return new HierarchyNodeModel();

            if (String.IsNullOrEmpty(path))
            {
                return new HierarchyNodeModel {
                    Children = new List<HierarchyNodeModel> {
                        new HierarchyNodeModel
                        {
                            Name = parent.Name,
                            Href = parent.Name
                        }
                    }
                };
            }

            var segmentedPath = path.Split('/').ToList();

            var nodeByPath = GetNodeByPath(hierarchyNodes, parent, segmentedPath);
            if (nodeByPath == null) return new HierarchyNodeModel(); 

            nodeByPath.Href = nodeByPath.Name;
            nodeByPath.Children.ForEach(_ => _.Href = $"{nodeByPath.Name}/{_.Name}");
            return nodeByPath;
        }

        private HierarchyNodeModel GetNodeByPath(List<HierarchyNode> hierarchyNodes, HierarchyNode parentNode, List<string> segmentedPath)
        {
            var currSegment = segmentedPath.First();
            if (parentNode == null || currSegment != parentNode.Name) return null;

            segmentedPath.Remove(currSegment);
            if (segmentedPath.Count == 0)
            {
                var children = hierarchyNodes.Where(_ => _.ParentId == parentNode.Id).ToList();
                return new HierarchyNodeModel
                {
                    Name = parentNode.Name,
                    Children = children.Select(_ => new HierarchyNodeModel { Name = _.Name }).ToList()
                };
            }

            parentNode = hierarchyNodes.FirstOrDefault(_ => _.ParentId == parentNode.Id && _.Name == segmentedPath.First());
            return GetNodeByPath(hierarchyNodes, parentNode, segmentedPath);
        }
    }
}