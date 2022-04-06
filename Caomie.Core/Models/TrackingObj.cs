using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace Caomei.Core.Models
{
    public class TrackingObj
    {
        public object Model { get; set; }
        public List<FieldIdentifier> ChangedFields { get; set; }
    }
}