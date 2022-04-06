using Caomei.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text.Json.Serialization;

namespace Caomei.Core
{
    /// <summary>
    /// FileAttachment
    /// </summary>
    [Table("FileAttachments")]
    public class FileAttachment : TopBasePoco, IWtmFile, IDisposable
    {
        [Display(Name = "Sys.FileName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string FileName { get; set; }

        [Display(Name = "Sys.FileExt")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(10)]
        public string FileExt { get; set; }

        [Display(Name = "Sys.Path")]
        public string Path { get; set; }

        [Display(Name = "Sys.Length")]
        public long Length { get; set; }

        public DateTime UploadTime { get; set; }

        public string SaveMode { get; set; }

        public byte[] FileData { get; set; }

        public string ExtraInfo { get; set; }
        public string HandlerInfo { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Stream DataStream { get; set; }

        public void Dispose()
        {
            if (DataStream != null)
            {
                DataStream.Dispose();
            }
        }

        string IWtmFile.GetID()
        {
            return ID.ToString();
        }
    }
}