using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace WalkingTec.Mvvm.Core
{
    public abstract class TreePoco : TopBasePoco
    {
        [Display(Name = "Sys.Parent")]
        public Guid? ParentId { get; set; }
    }

    public class TreePoco<T> : TreePoco where T : TreePoco<T>
    {
        [Display(Name = "Sys.Parent")]
        [JsonIgnore]
        public T Parent { get; set; }

        [InverseProperty("Parent")]
        [Display(Name = "Sys.Children")]
        public List<T> Children { get; set; }

        [NotMapped]
        public bool HasChildren
        {
            get
            {
                return Children?.Any() == true;
            }
        }
    }
}