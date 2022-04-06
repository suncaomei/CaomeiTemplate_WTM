using Caomei.Core;
using Caomei.Core.Extensions;
using Caomei.Mvc;
using Caomei.ViewModel.Admin.FrameworkUserVMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caomei.Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    [ActionDescription("MenuKey.UserManagement")]
    [ApiController]
    [Route("/api/_Admin/FrameworkUser")]
    public partial class FrameworkUserController : BaseApiController
    {
        [ActionDescription("Sys.Get")]
        [HttpGet("{id}")]
        public FrameworkUserVM Get(string id)
        {
            var vm = Wtm.CreateVM<FrameworkUserVM>(id);
            vm.Entity.Password = "";
            return vm;
        }

        [ActionDescription("Sys.Create")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(FrameworkUserVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.Entity.Password = Utils.GetMD5String(vm.Entity.Password);
                await vm.DoAddAsync();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }

        [ActionDescription("Sys.Edit")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(FrameworkUserVM vm)
        {
            ModelState.Remove("Entity.Password");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                if (string.IsNullOrEmpty(vm.Entity.Password) == false)
                {
                    vm.Entity.Password = Utils.GetMD5String(vm.Entity.Password);
                }
                else
                {
                    vm.FC.Remove("Entity.Password");
                }
                await vm.DoEditAsync(false);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }

        [HttpPost("BatchEdit")]
        [ActionDescription("Sys.BatchEdit")]
        public ActionResult BatchEdit(FrameworkUserBatchVM vm)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(vm.Ids.Count());
            }
        }

        [HttpPost("BatchDelete")]
        [ActionDescription("Sys.Delete")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = Wtm.CreateVM<FrameworkUserBatchVM>();
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

        [ActionDescription("Sys.DownloadTemplate")]
        [HttpGet("GetExcelTemplate")]
        public IActionResult GetExcelTemplate()
        {
            var vm = Wtm.CreateVM<FrameworkUserImportVM>();
            var qs = new Dictionary<string, string>();
            foreach (var item in Request.Query.Keys)
            {
                qs.Add(item, Request.Query[item]);
            }
            vm.SetParms(qs);
            var data = vm.GenerateTemplate(out string fileName);
            return File(data, "application/vnd.ms-excel", fileName);
        }

        [ActionDescription("Sys.Import")]
        [HttpPost("Import")]
        public ActionResult Import(FrameworkUserImportVM vm)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return BadRequest(vm.GetErrorJson());
            }
            else
            {
                return Ok(vm.EntityList.Count);
            }
        }

        [HttpGet("GetFrameworkRoles")]
        public ActionResult GetFrameworkRoles()
        {
            return Ok(DC.Set<FrameworkRole>().GetSelectListItems(Wtm, x => x.RoleName));
        }

        [HttpGet("GetFrameworkGroups")]
        public ActionResult GetFrameworkGroups()
        {
            return Ok(DC.Set<FrameworkGroup>().GetSelectListItems(Wtm, x => x.GroupName));
        }
    }
}