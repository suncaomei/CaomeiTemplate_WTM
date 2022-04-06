using Caomei.Core;
using System;

namespace Caomei.Mvc
{
    public static class ActionDescriptionExtension
    {
        public static string GetDescription(this ActionDescriptionAttribute self, IBaseController controller)
        {
            return self.GetDescription(controller.GetType());
        }

        public static string GetDescription(this ActionDescriptionAttribute self, Type controllertype)
        {
            string rv = "";
            if (string.IsNullOrEmpty(self.Description) == false)
            {
                rv = CoreProgram._localizer?[self.Description];
            }
            return rv;
        }
    }
}