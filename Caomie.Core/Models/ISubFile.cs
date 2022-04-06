using System;

namespace Caomei.Core
{
    public interface ISubFile
    {
        Guid FileId { get; set; }
        FileAttachment File { get; set; }
        int Order { get; set; }
    }
}