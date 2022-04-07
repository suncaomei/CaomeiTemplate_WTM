using Caomei.Core;
using Caomei.Core.Attributes;
using Caomei.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Caomei.Mvc
{
    // public partial class FrameworkUserListVM : BasePagedListVM<FrameworkUser_View, FrameworkUserSearcher>

    public partial class CodeGenListVM : BasePagedListVM<CodeGenListView, BaseSearcher>
    {
        public string ModelFullName { get; set; }

        public CodeGenListVM()
        {
            NeedPage = false;
        }

        // protected override IEnumerable<IGridColumn<FrameworkUser_View>> InitGridHeader()
        protected override IEnumerable<IGridColumn<CodeGenListView>> InitGridHeader()
        {
            return new List<IGridColumn<CodeGenListView>>
            {
                this.MakeGridHeader(x => x.FieldName),
                this.MakeGridHeader(x => x.FieldDes),
                this.MakeGridHeader(x => x.SubField),
                this.MakeGridHeader(x => x.IsSearcherField),
                this.MakeGridHeader(x => x.IsListField),
                this.MakeGridHeader(x => x.IsFormField),
                this.MakeGridHeader(x => x.IsBatchField),
                this.MakeGridHeader(x => x.IsImportField),
          };
        }

        private string getCheckBox(string fieldname, bool val)
        {
            return UIService.MakeCheckBox(val, name: fieldname, value: "true");
        }

        private string withHidden(string fieldname, string val)
        {
            return val + $"<input type='hidden' name='{fieldname}' value='{val}' />";
        }

        private string subField(string fieldname, CodeGenListView entity)
        {
            string rv = $"<input type='hidden' name='{fieldname}.RelatedField' value='{entity.LinkedType}' />";
            rv += $"<input type='hidden' name='{fieldname}.SubIdField' value='{entity.SubIdField}' />";
            if (string.IsNullOrEmpty(entity.LinkedType) == false)
            {
                var linktype = Type.GetType(entity.LinkedType);
                if (linktype != typeof(FileAttachment))
                {
                    var subpros = Type.GetType(entity.LinkedType).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(x => x.GetMemberType() == typeof(string) && x.Name != "BatchError").OrderBy(x => x.Name).ToList().ToListItems(x => x.Name, x => x.Name);
                    var subproswithname = subpros.Where(x => x.Text.ToLower().Contains("name")).ToList();
                    var subproswithoutname = subpros.Where(x => x.Text.ToLower().Contains("name") == false).ToList();
                    subpros = new List<ComboSelectListItem>();
                    subpros.AddRange(subproswithname);
                    subpros.AddRange(subproswithoutname);
                    if (subpros.Count == 0)
                    {
                        subpros.Add(new ComboSelectListItem { Text = "Id", Value = "Id" });
                    }
                    rv += UIService.MakeCombo(fieldname + ".SubField", subpros);
                }
                else
                {
                    rv += $"<input type='hidden' name='{fieldname}.SubField' value='`file' />";
                }
            }
            return rv;
        }

        // public override IOrderedQueryable<FrameworkUser_View> GetSearchQuery()

        public override IOrderedQueryable<CodeGenListView> GetSearchQuery()
        {
            Type modeltype = Type.GetType(ModelFullName);
            var pros = modeltype.GetAllProperties();
            List<CodeGenListView> lv = new List<CodeGenListView>();
            List<string> skipFields = new List<string>()
            {
               nameof(TopBasePoco.BatchError),
               nameof(TopBasePoco.Checked),
               nameof(TopBasePoco.ExcelIndex),
            };
            //if (typeof(IBasePoco).IsAssignableFrom(modeltype))
            //{
            //    skipFields.AddRange(
            //        new string[]{
            //   nameof(IBasePoco.CreateBy),
            //   nameof(IBasePoco.CreateTime),
            //   nameof(IBasePoco.UpdateBy),
            //   nameof(IBasePoco.UpdateTime) }
            //        );
            //}
            //if (typeof(IPersistPoco).IsAssignableFrom(modeltype))
            //{
            //    skipFields.Add(nameof(IPersistPoco.IsValid));
            //}

            List<string> ignoreField = new List<string>();
            foreach (var pro in pros)
            {
                if (skipFields.Contains(pro.Name) == false)
                {
                    if (pro.CanWrite == false)
                    {
                        continue;
                    }
                    if (pro.Name.ToLower() == "id" && pro.PropertyType != typeof(string))
                    {
                        continue;
                    }
                    CodeGenListView view = new CodeGenListView()
                    {
                        FieldName = pro.Name,
                        FieldDes = pro.GetPropertyDisplayName(),
                        SubIdField = "",
                    };
                    var notmapped = pro.GetCustomAttributes(typeof(NotMappedAttribute), false).FirstOrDefault();
                    Type checktype = pro.PropertyType;
                    if (pro.PropertyType.IsNullable())
                    {
                        checktype = pro.PropertyType.GetGenericArguments()[0];
                    }
                    if (ignoreField.Contains(checktype.Name))
                    {
                        continue;
                    }
                    bool show = false;
                    view.IsFormField = true;
                    view.IsListField = true;
                    view.IsImportField = true;
                    view.IsSearcherField = true;
                    view.IsBatchField = true;
                    if (checktype.IsPrimitive || checktype == typeof(string) || checktype == typeof(DateTime) || checktype.IsEnum() || checktype == typeof(decimal))
                    {
                        show = true;
                    }
                    if (typeof(TopBasePoco).IsAssignableFrom(checktype))
                    {
                        var fk = DC.GetFKName2(modeltype, pro.Name);
                        if (fk != null)
                        {
                            ignoreField.Add(fk);
                            show = true;
                        }
                        if (checktype == typeof(FileAttachment))
                        {
                            view.IsImportField = false;
                            view.IsBatchField = false;
                            view.FieldDes += $"({Localizer["Codegen.Attachment"]})";
                        }
                        else
                        {
                            view.FieldDes += $"({MvcProgram._localizer["Codegen.OneToMany"]})";
                        }
                        view.LinkedType = checktype.AssemblyQualifiedName;
                        if (fk != null)
                        {
                            if (modeltype.GetSingleProperty(fk) == null)
                            {
                                view.FieldDes = $"<font color='#ff0000'>(Error:Can't find {fk.Replace("ID", "Id")} in {checktype.Name})</font>";
                            }
                        }
                    }
                    if (checktype.IsList())
                    {
                        checktype = pro.PropertyType.GetGenericArguments()[0];
                        if (checktype.IsNullable())
                        {
                            checktype = checktype.GetGenericArguments()[0];
                        }
                        var middletable = checktype.GetCustomAttributes(typeof(MiddleTableAttribute), false).FirstOrDefault();
                        if (middletable != null)
                        {
                            view.FieldDes += $"({MvcProgram._localizer["Codegen.ManyToMany"]})";
                            view.IsImportField = false;
                            view.IsBatchField = false;
                            var subpros = checktype.GetAllProperties();
                            foreach (var spro in subpros)
                            {
                                if (skipFields.Contains(spro.Name) == false)
                                {
                                    Type subchecktype = spro.PropertyType;
                                    if (spro.PropertyType.IsNullable())
                                    {
                                        subchecktype = spro.PropertyType.GetGenericArguments()[0];
                                    }
                                    if (typeof(TopBasePoco).IsAssignableFrom(subchecktype) && subchecktype != modeltype)
                                    {
                                        view.LinkedType = subchecktype.AssemblyQualifiedName;
                                        var fk = DC.GetFKName2(checktype, spro.Name);
                                        view.SubIdField = fk;
                                        show = true;
                                        if (checktype.GetSingleProperty(fk) == null)
                                        {
                                            view.FieldDes = $"<font color='#ff0000'>(Error:Can't find {fk.Replace("ID", "Id")} in {checktype.Name})</font>";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (notmapped != null)
                    {
                        view.FieldDes += "(NotMapped)";
                        view.IsFormField = false;
                        view.IsSearcherField = false;
                        view.IsBatchField = false;
                        view.IsImportField = false;
                        view.IsListField = false;
                    }
                    if (show == true)
                    {
                        lv.Add(view);
                    }
                }
            }

            for (int i = 0; i < lv.Count; i++)
            {
                if (ignoreField.Contains(lv[i].FieldName))
                {
                    lv.RemoveAt(i);
                    i--;
                }
                if (lv[i].FieldName=="UpdateTime"||lv[i].FieldName=="UpdateBy")
                {
                    lv[i].IsImportField=false;
                    lv[i].IsSearcherField=false;
                    lv[i].IsFormField=false;
                    lv[i].IsListField=false;
                    lv[i].IsBatchField=false;
                }
                if (lv[i].FieldName=="CreateTime"||lv[i].FieldName=="CreateBy")
                {
                    lv[i].IsImportField=false;
                    lv[i].IsFormField=false;
                    lv[i].IsBatchField=false;
                }
            }

            return lv.AsQueryable().OrderBy(x => x.ID);
        }
    }

    public class CodeGenListView : BasePoco
    {
        [Display(Name = "Sys.FieldName")]
        public string FieldName { get; set; }

        [Display(Name = "Codegen.FieldDes")]
        public string FieldDes { get; set; }

        [Display(Name = "Codegen.IsSearcherField")]
        public bool IsSearcherField { get; set; }

        [Display(Name = "Codegen.IsListField")]
        public bool IsListField { get; set; }

        [Display(Name = "Codegen.IsFormField")]
        public bool IsFormField { get; set; }

        [Display(Name = "Codegen.SubField")]
        public string SubField { get; set; }

        public string SubIdField { get; set; }

        [Display(Name = "Codegen.IsImportField")]
        public bool IsImportField { get; set; }

        [Display(Name = "Codegen.IsBatchField")]
        public bool IsBatchField { get; set; }

        [Display(Name = "Codegen.LinkedType")]
        public string LinkedType { get; set; }
    }
}