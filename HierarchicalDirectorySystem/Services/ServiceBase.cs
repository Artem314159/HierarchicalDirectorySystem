using HierarchicalDirectorySystem.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Services
{
    public abstract class ServiceBase
    {
        protected readonly DirectorySystemContext db;

        public ServiceBase(DirectorySystemContext db)
        {
            this.db = db;
        }
    }
}