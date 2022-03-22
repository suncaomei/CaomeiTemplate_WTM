using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace WalkingTec.Mvvm.Core.Models
{
    public class TrackingObj
    {
        public object Model { get; set; }
        public List<FieldIdentifier> ChangedFields { get; set; }
    }
}