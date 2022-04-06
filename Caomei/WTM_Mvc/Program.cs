using Caomei.Core;
using Microsoft.Extensions.Localization;

namespace Caomei.Mvc
{
    public class MvcProgram
    {
        public static IStringLocalizer _localizer = CoreProgram._localizer;
    }
}