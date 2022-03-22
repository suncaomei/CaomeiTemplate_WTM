using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    public enum ActionLogTypesEnum
    {
        [Display(Name = "Sys.Normal")]
        Normal,

        [Display(Name = "Sys.Exception")]
        Exception,

        [Display(Name = "Sys.Debug")]
        Debug
    };

    /// <summary>
    /// ActionLog
    /// </summary>
    [Table("ActionLogs")]
    public class ActionLog : BasePoco, ICloneable
    {
        [Display(Name = "Sys.Module")]
        [StringLength(255, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ModuleName { get; set; }

        [Display(Name = "Sys.Action")]
        [StringLength(255, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ActionName { get; set; }

        [Display(Name = "Sys.Account")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ITCode { get; set; }

        [Display(Name = "Url")]
        [StringLength(250, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ActionUrl { get; set; }

        [Display(Name = "Sys.ActionTime")]
        public DateTime ActionTime { get; set; }

        [Display(Name = "Sys.Duration")]
        public double Duration { get; set; }

        [Display(Name = "Sys.Remark")]
        public string Remark { get; set; }

        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Display(Name = "IP")]
        public string IP { get; set; }

        [Display(Name = "Sys.LogType")]
        public ActionLogTypesEnum LogType { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string GetLogString()
        {
            return $@"
|-{Core.CoreProgram._localizer?["Sys.ActionTime"]}：{this.ActionTime}
|-{Core.CoreProgram._localizer?["Sys.Account"]}：{this.ITCode ?? ""}
|-IP：{this.IP ?? ""}
|-{Core.CoreProgram._localizer?["Sys.Module"]}：{this.ModuleName ?? ""}
|-{Core.CoreProgram._localizer?["Sys.MethodName"]}：{this.ActionName ?? ""}
|-Url：{this.ActionUrl ?? ""}
|-{Core.CoreProgram._localizer?["Sys.Duration"]}：{this.Duration.ToString("F2") + " s"}
|-{Core.CoreProgram._localizer?["Sys.Remark"]}：{this.Remark}
";
        }
    }
}