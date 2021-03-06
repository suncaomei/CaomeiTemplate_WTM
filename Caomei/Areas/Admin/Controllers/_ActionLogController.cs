// WTM默认页面 Wtm buidin page
using Caomei.Core;
using Caomei.Core.Extensions;
using Caomei.Mvc;
using Caomei.ViewModel.Admin.ViewModels.ActionLogVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Caomei.Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    [ActionDescription("MenuKey.ActionLog")]
    [ApiController]
    [Route("api/_[controller]")]
    public class ActionLogController : BaseApiController
    {
        [ActionDescription("Sys.Search")]
        [HttpPost("[action]")]
        public string Search(ActionLogSearcher searcher)
        {
            var vm = Wtm.CreateVM<ActionLogListVM>(passInit: true);
            vm.Searcher = searcher;
            return vm.GetJson(enumToString: false);
        }

        [ActionDescription("Sys.Get")]
        [HttpGet("{id}")]
        public ActionLogVM Get(Guid id)
        {
            var vm = Wtm.CreateVM<ActionLogVM>(id);
            return vm;
        }

        [HttpPost("[action]")]
        [ActionDescription("Sys.Delete")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = Wtm.CreateVM<ActionLogBatchVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(ids.Count());
            }
        }

        [ActionDescription("Sys.Export")]
        [HttpPost("[action]")]
        public IActionResult ExportExcel(ActionLogSearcher searcher)
        {
            var vm = Wtm.CreateVM<ActionLogListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.ExportByIds")]
        [HttpPost("[action]")]
        public IActionResult ExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<ActionLogListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }
    }
}