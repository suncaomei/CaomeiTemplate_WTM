using Caomei.Core;
using Caomei.Core.Extensions;
using Caomei.Core.Support.Quartz;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Caomei.Mvc.Helper
{
    [QuartzRepeat(3600, 0, true)]
    [QuartzJob("RefreshJwt")]
    [QuartzGroup("Wtm_System")]
    public class JwtRefreshJob : WtmJob
    {
        public override Task Execute(IJobExecutionContext context)
        {
            try
            {
                var sql = $"DELETE FROM {this.Wtm.DC.GetTableName<PersistedGrant>()} WHERE Expiration<'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}'";
                this.Wtm.DC.RunSQL(sql);
                Wtm.DoLog("清理过期的refreshToken", ActionLogTypesEnum.Job);
            }
            catch { }
            return Task.CompletedTask;
        }
    }
}