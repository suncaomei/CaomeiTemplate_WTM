using Caomei.Core;
using Caomei.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Caomei.Mvc
{
    [DebugOnly]
    [ApiController]
    [Route("api/_[controller]")]
    [ActionDescription("Sys.CodeGen")]
    public class CodeGenController : BaseApiController
    {
        [ActionDescription("Sys.CodeGen")]
        [HttpPost("[action]")]
        public IActionResult Index(CodeGenVM postvm)
        {
            var vm = Wtm.CreateVM<CodeGenVM>();
            vm.UI = postvm.UI;
            vm.EntryDir = AppDomain.CurrentDomain.BaseDirectory;
            vm.AllModels = GetAllModels().ToListItems(x => x.Name, x => x.AssemblyQualifiedName);
            vm.FieldList.ModelFullName = postvm.SelectedModel;
            vm.SelectedModel = postvm.SelectedModel;

            return Ok(vm);
        }

        [HttpGet("[action]")]
        public IActionResult AllModels()
        {
            return Ok(GetAllModels().ToListItems(x => x.Name, x => x.AssemblyQualifiedName));
        }

        public class PostVM
        {
            public UIEnum UI { get; set; }
            public string SelectedModel { get; set; }
            public string ModuleName { get; set; }
            public string Area { get; set; }
            public List<FieldInfo> FieldInfos { get; set; }
        }

        [HttpPost("[action]")]
        [ActionDescription("Codegen.ConfigurationField")]
        public IActionResult SetField(PostVM post)
        {
            var vm = Wtm.CreateVM<CodeGenListVM>();
            vm.ModelFullName=post.SelectedModel;
            return Ok(vm.GetJson(enumToString: false));
        }

        [HttpPost("[action]")]
        [ActionDescription("Codegen.GenerateConfirmation")]
        public IActionResult Gen(PostVM post)
        {
            var vm = Wtm.CreateVM<CodeGenVM>();
            vm.EntryDir = AppDomain.CurrentDomain.BaseDirectory;
            vm.UI = post.UI;
            vm.Area = post.Area;
            vm.FieldInfos = post.FieldInfos;
            vm.ModuleName = post.ModuleName;
            vm.SelectedModel = post.SelectedModel;
            vm.SetDC();
            return Ok(vm);
        }

        [HttpPost("[action]")]
        public IActionResult DoGen(CodeGenVM vm)
        {
            vm.DoGen();
            //return FFResult().Alert(MvcProgram._localizer["Codegen.Success"]);
            return Ok();
        }

        [ActionDescription("Codegen.Preview")]
        [HttpPost("[action]")]
        public IActionResult Preview(CodeGenVM vm)
        {
            vm.SetDC();

            var code = string.Empty;
            if (vm.PreviewFile == "Controller")
            {
                //ViewData["filename"] = $"{vm.ModelName}{(vm.IsApi == true ? "Api" : "")}Controller.cs";
                code = vm.GenerateController();
            }
            else if (vm.PreviewFile == "Searcher" || vm.PreviewFile.EndsWith("VM"))
            {
                //ViewData["filename"] = vm.ModelName + $"{(vm.IsApi == true ? "Api" : "")}" + vm.PreviewFile.Replace("CrudVM", "VM") + ".cs";
                code = vm.GenerateVM(vm.PreviewFile);
            }
            else if (vm.UI == UIEnum.React)
            {
                if (vm.PreviewFile == "storeindex")
                {
                    code = vm.GetResource("index.txt", "Spa.React.store").Replace("$modelname$", vm.ModelName.ToLower());
                }
                else if (vm.PreviewFile == "index")
                {
                    code = vm.GetResource("index.txt", "Spa.React").Replace("$modelname$", vm.ModelName.ToLower());
                }
                else if (vm.PreviewFile == "style")
                {
                    code = vm.GetResource("style.txt", "Spa.React").Replace("$modelname$", vm.ModelName.ToLower());
                }
                else
                {
                    code = vm.GenerateReactView(vm.PreviewFile);
                }
            }
            else if (vm.UI == UIEnum.VUE||vm.UI==UIEnum.BlazorAndVue)
            {
                List<string> apineeded = new List<string>();
                code = vm.GenerateVUEView(vm.PreviewFile, apineeded);
            }
            else if (vm.UI == UIEnum.Blazor||vm.UI==UIEnum.BlazorAndVue)
            {
                code = vm.GenerateBlazorView(vm.PreviewFile);
            }
            else if (vm.PreviewFile.EndsWith("View"))
            {
                //ViewData["filename"] = vm.PreviewFile.Replace("ListView", "Index").Replace("View", "") + "cshtml";
                code = vm.GenerateView(vm.PreviewFile);
            }
            return Ok(code);
        }

        private List<Type> GetAllModels()
        {
            var models = new List<Type>();

            //获取所有模型
            var pros = Wtm.ConfigInfo.Connections.SelectMany(x => x.DcConstructor.DeclaringType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance));
            if (pros != null)
            {
                foreach (var pro in pros)
                {
                    if (pro.PropertyType.IsGeneric(typeof(DbSet<>)))
                    {
                        models.Add(pro.PropertyType.GetGenericArguments()[0]);
                    }
                }
            }
            return models;
        }

        //[ActionDescription("创建模型中英文资源")]
        //[HttpPost("[action]")]
        //[Public]
        //public IActionResult Create(Resx resx)
        //{
        //    return Ok();
        //}
        [HttpPost("[action]")]
        public IActionResult CreatModel(Resx resx)
        {
            var abstractstr = resx.IsAbstract ? "abstract" : String.Empty;
            var models1 =
                  $"using System.ComponentModel.DataAnnotations;" +
                  $"\n" +
                  $"using Caomei.Core;" +
                  $"\n" +
                  $"namespace {resx.ProjectName_en}.Model.{resx.AreasName_en}" +
                  $"\n" +
                  $"{{    /// <summary>" +
                  $"\n" +
                  $"     /// {resx.ModelName_cn}" +
                  $"\n" +
                  $"     /// </summary>" +
                  $"\n" +
                  $"    [Display(Name = \"Model.{resx.ModelName_en}\")]" +
                  $"\n" +
                  $"    public {abstractstr} class {resx.ModelName_en} : {resx.BaseModel}" +
                  $"\n" +
                  $"    {{" +
                  $"\n"
                  ;
            var models3 =
                  $"    }}" +
                  $"\n" +
                  $"}}";
            var models2 = string.Empty;
            foreach (var item in resx.ModelField_List)
            {
                string ModelField_en = item.ModelField_en;
                string ModelField_cn = item.ModelField_cn;
                models2 +=
                    $"        [Display(Name = \"{resx.ModelName_en}.{ModelField_en}\")]" +
                    $"\n" +
                    $"        public string {ModelField_en} {{ get; set; }}" +
                    $"\n";
            }
            return Ok(models1 + models2 + models3);
        }

        [HttpPost("[action]")]
        public IActionResult CreatResx(Resx resx)
        {
            var base_en =
                   $"  <data name=\"Model.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                   $"\n" +
                   $"    <value>{resx.ModelName_en}</value>" +
                   $"\n" +
                   $"  </data>" +
                   $"\n" +
                   $"  <data name=\"MenuKey.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                   $"\n" +
                   $"    <value>{resx.ModelName_en}Management</value>" +
                   $"\n" +
                   $"  </data>" +
                   $"\n";
            var base_cn =
                    $"  <data name=\"Model.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                    $"\n" +
                    $"    <value>{resx.ModelName_cn}</value>" +
                    $"\n" +
                    $"  </data>" +
                    $"\n" +
                    $"  <data name=\"MenuKey.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                    $"\n" +
                    $"    <value>{resx.ModelName_cn}管理</value>" +
                    $"\n" +
                    $"  </data>" +
                    $"\n";
            var modelField_en = string.Empty;
            var modelField_cn = string.Empty;
            foreach (var item in resx.ModelField_List)
            {
                string ModelField_en = item.ModelField_en;
                string ModelField_cn = item.ModelField_cn;
                modelField_en +=
                    $"  <data name=\"{resx.ModelName_en}.{ModelField_en}\" xml:space=\"preserve\">" +
                    $"\n" +
                    $"    <value>{ModelField_en}</value>" +
                    $"\n" +
                    $"  </data>" +
                    $"\n";
                modelField_cn +=
                    $"  <data name=\"{resx.ModelName_en}.{ModelField_en}\" xml:space=\"preserve\">" +
                    $"\n" +
                    $"    <value>{ModelField_cn}</value>" +
                    $"\n" +
                    $"  </data>" +
                    $"\n";
            }
            return Ok(base_en + modelField_en + "\n\n\n\n\n" + base_cn + modelField_cn);
        }

        [HttpPost("[action]")]
        public IActionResult CreatVueResx(Resx resx)
        {
            var MenuKey_en = $"        'MenuKey_{resx.ModelName_en}Management': '{resx.ModelName_en}Management',";
            var MenuKey_cn = $"        'MenuKey_{resx.ModelName_en}Management': '{resx.ModelName_cn}管理',";
            var model_en = $"        'Model_{resx.ModelName_en}': '{resx.ModelName_en}',";
            var model_cn = $"        'Model_{resx.ModelName_en}': '{resx.ModelName_cn}',";
            var page_en = $"        'PageName.{resx.AreasName_en.ToLower()}-{resx.ModelName_en.ToLower()}': '{resx.ModelName_en}Management',";
            var page_cn = $"        'PageName.{resx.AreasName_en.ToLower()}-{resx.ModelName_en.ToLower()}': '{resx.ModelName_cn}管理',";
            var modelField_en = string.Empty;
            var modelField_cn = string.Empty;
            foreach (var item in resx.ModelField_List)
            {
                string ModelField_en = item.ModelField_en;
                string ModelField_cn = item.ModelField_cn;
                modelField_en +=
                    $"        '{resx.ModelName_en}_{ModelField_en}': '{item.ModelField_en}'," +
                    $"\n";
                modelField_cn +=
                    $"        '{resx.ModelName_en}_{ModelField_en}': '{item.ModelField_cn}'," +
                    $"\n";
            }
            return Ok(MenuKey_en+"\n"+model_en+"\n"+page_en+"\n"+modelField_en + "\n\n\n\n\n" +MenuKey_cn+"\n"+model_cn+"\n"+page_cn+"\n"+ modelField_cn);
        }

        [HttpGet("[action]")]
        public IActionResult GetMainNS()
        {
            var vm = Wtm.CreateVM<CodeGenVM>();
            vm.EntryDir = AppDomain.CurrentDomain.BaseDirectory;

            return Ok(vm.MainNS);
        }
    }

    public class Resx
    {
        //是否虚方法
        public string BaseModel { get; set; }

        public bool IsAbstract { get; set; } = false;
        public string ProjectName_en { get; set; }
        public string AreasName_en { get; set; }
        public string ModelName_en { get; set; }
        public string ModelName_cn { get; set; }
        public List<ModelField_List> ModelField_List { get; set; }
    }

    public class ModelField_List
    {
        public string ModelField_en { get; set; }
        public string ModelField_cn { get; set; }
    }
}