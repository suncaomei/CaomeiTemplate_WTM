using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc
{
    [AuthorizeJwtWithCookie]
    [ActionDescription("Sys.CodeGen")]
    [ApiController]
    [Route("/api/CodeGen")]
    public class CodeGenController : ControllerBase
    {
        [ActionDescription("创建模型中英文资源")]
        [HttpPost("[action]")]
        [Public]
        public IActionResult Create(Resx resx)
        {
            string base_en = string.Empty, base_cn = string.Empty, modelField_cn = string.Empty, modelField_en = string.Empty, models1 = string.Empty, models2 = string.Empty, models3 = string.Empty;
            var abstractstr = resx.IsAbstract ? "abstract" : String.Empty;
            models1 =
                $"using System.ComponentModel.DataAnnotations;" +
                $"\n" +
                $"using WalkingTec.Mvvm.Core;" +
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
                $"    public {abstractstr} class {resx.ModelName_en} : BasePoco" +
                $"\n" +
                $"    {{" +
                $"\n"
                ;
            models3 =
                $"    }}" +
                $"\n" +
                $"}}";
            base_en =
                $"  <data name=\"Model.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                $"\n" +
                $"    <value>{resx.ModelName_en}</value>" +
                $"\n" +
                $"  </data>" +
                $"\n" +
                $"  <data name=\"MenuKey.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                $"\n" +
                $"    <value>{resx.ModelName_en}</value>" +
                $"\n" +
                $"  </data>" +
                $"\n";
            base_cn =
                $"  <data name=\"Model.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                $"\n" +
                $"    <value>{resx.ModelName_cn}</value>" +
                $"\n" +
                $"  </data>" +
                $"\n" +
                $"  <data name=\"MenuKey.{resx.ModelName_en}\" xml:space=\"preserve\">" +
                $"\n" +
                $"    <value>{resx.ModelName_cn}</value>" +
                $"\n" +
                $"  </data>" +
                $"\n";
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
                models2 +=
                    $"        [Display(Name = \"{resx.ModelName_en}.{ModelField_en}\")]" +
                    $"\n" +
                    $"        public string {ModelField_en} {{ get; set; }}" +
                    $"\n";
            }
            return Ok(resx.ModelName_en + "\n\n\n" + models1 + models2 + models3 + "\n\n\n\n\n" + base_en + modelField_en + "\n\n\n\n\n" + base_cn + modelField_cn);
        }

        public class Resx
        {
            //是否虚方法
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
}