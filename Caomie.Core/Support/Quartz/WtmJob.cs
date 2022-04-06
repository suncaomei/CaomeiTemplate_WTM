using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Caomei.Core.Support.Quartz
{
    public class WtmJob : IJob, IDisposable
    {
        private IServiceScope _ss;
        private WTMContext _wtm;

        protected WTMContext Wtm
        {
            get
            {
                if (_wtm == null)
                {
                    _ss = Sp.CreateScope();
                    _wtm = _ss.ServiceProvider.GetRequiredService<WTMContext>();
                }
                return _wtm;
            }
        }

        public IServiceProvider Sp { get; set; }

        public virtual async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => { });
        }

        public void Dispose()
        {
            _ss.Dispose();
        }
    }
}