using Caomei.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Caomei.Mvc
{
    public static class ActionExecutingContextExtension
    {
        public static void SetWtmContext(this ActionExecutingContext self)
        {
            var controller = self.Controller as IBaseController;
            if (controller == null)
            {
                return;
            }
            if (controller.Wtm == null)
            {
                controller.Wtm = self.HttpContext.RequestServices.GetRequiredService<WTMContext>();
            }
            try
            {
                controller.Wtm.MSD = new ModelStateServiceProvider(self.ModelState);
                controller.Wtm.Session = new SessionServiceProvider(self.HttpContext.Session);
            }
            catch { }
        }
    }
}