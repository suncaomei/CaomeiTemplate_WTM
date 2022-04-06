using System;

namespace Caomei.Core.Support.Json
{
    [Serializable]
    public class SimpleDataPri
    {
        public Guid ID { get; set; }

        public string UserCode { get; set; }
        public string GroupCode { get; set; }

        public string TableName { get; set; }

        public string RelateId { get; set; }
    }
}