using HierarchicalDirectorySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Core.Context
{
    public class DirectorySystemContext : DbContext
    {
        public DirectorySystemContext() : base("name=DirectorySystem")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DirectorySystemContext(string stringConnection) : base(stringConnection)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DirectorySystemContext(DbConnection connection) : base(connection, false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<HierarchyNode> HierarchyNodes { get; set; }
    }
}