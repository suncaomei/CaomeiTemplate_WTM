using Caomei.Core;
using Caomei.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caomei.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype) : base(cs, dbtype)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version = null) : base(cs, dbtype, version)
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = Set<FrameworkUser>().Count() == 0 && Set<FrameworkUserRole>().Count() == 0;
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin",
                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                var adminmenus = Set<FrameworkMenu>().Where(x => x.Url != null && x.Url.StartsWith("/api") == false).ToList();
                foreach (var item in adminmenus)
                {
                    item.Url = "/_admin" + item.Url;
                }
                await SaveChangesAsync();
                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                await SaveChangesAsync();
                try
                {
                    Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
                }
                catch { }
            }
            return state;
        }

        private void SetTestData(Type modelType, Dictionary<string, List<object>> data, int count = 100)
        {
            if (data.ContainsKey(modelType.FullName) && data[modelType.FullName].Count >= count)
            {
                return;
            }
            using (var dc = this.CreateNew())
            {
                Random r = new Random();
                data[modelType.FullName] = new List<object>();
                int retry = 0;
                List<string> ids = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    var modelprops = modelType.GetRandomValuesForTestData();
                    var newobj = modelType.GetConstructor(Type.EmptyTypes).Invoke(null);
                    var idvalue = modelprops.Where(x => x.Key == "ID").Select(x => x.Value).SingleOrDefault();
                    if (idvalue != null)
                    {
                        if (ids.Contains(idvalue.ToLower()) == false)
                        {
                            ids.Add(idvalue.ToLower());
                        }
                        else
                        {
                            retry++;
                            i--;
                            if (retry > count)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    foreach (var pro in modelprops)
                    {
                        if (pro.Value == "$fk$")
                        {
                            var fktype = modelType.GetSingleProperty(pro.Key[0..^2])?.PropertyType;
                            if (fktype != modelType && typeof(TopBasePoco).IsAssignableFrom(fktype) == true)
                            {
                                try
                                {
                                    SetTestData(fktype, data, count);
                                    newobj.SetPropertyValue(pro.Key, (data[fktype.FullName][r.Next(0, data[fktype.FullName].Count)] as TopBasePoco).GetID());
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            var v = pro.Value;
                            if (v.StartsWith("\""))
                            {
                                v = v[1..];
                            }
                            if (v.EndsWith("\""))
                            {
                                v = v[..^1];
                            }
                            newobj.SetPropertyValue(pro.Key, v);
                        }
                    }
                    if (modelType == typeof(FileAttachment))
                    {
                        newobj.SetPropertyValue("Path", "./wwwroot/logo.png");
                        newobj.SetPropertyValue("SaveMode", "local");
                        newobj.SetPropertyValue("Length", 16728);
                    }
                    if (typeof(IBasePoco).IsAssignableFrom(modelType))
                    {
                        newobj.SetPropertyValue("CreateTime", DateTime.Now);
                        newobj.SetPropertyValue("CreateBy", "admin");
                    }
                    if (typeof(IPersistPoco).IsAssignableFrom(modelType))
                    {
                        newobj.SetPropertyValue("IsValid", true);
                    }
                    try
                    {
                        (dc as DbContext).Add(newobj);
                        data[modelType.FullName].Add(newobj);
                    }
                    catch
                    {
                        retry++;
                        i--;
                        if (retry > count)
                        {
                            break;
                        }
                    }
                }
                try
                {
                    dc.SaveChanges();
                }
                catch { }
            }
        }
    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string, EF will find this class
    /// and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("your full connection string", DBTypeEnum.SqlServer);
        }
    }
}