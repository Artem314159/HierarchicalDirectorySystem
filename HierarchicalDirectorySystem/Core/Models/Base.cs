using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace HierarchicalDirectorySystem.Core.Models
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        [Key()]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
    }

    public abstract class NamedEntity : EntityBase
    {
        [Required, Column]
        public string Name { get; set; }
    }

}