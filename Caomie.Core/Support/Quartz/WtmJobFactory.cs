using Quartz;
using Quartz.Spi;
using System;

namespace Caomei.Core.Support.Quartz
{
    public class WtmJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var rv = Activator.CreateInstance(bundle.JobDetail.GetType()) as IJob;
            return rv;
        }

        public void ReturnJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}