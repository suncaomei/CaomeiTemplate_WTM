using Microsoft.Extensions.Localization;
using System.Text.Json;

namespace Caomei.Core
{
    public class CoreProgram
    {
        public static IStringLocalizer _localizer
        {
            get;
            set;
        }

        public static JsonSerializerOptions DefaultJsonOption
        {
            get; set;
        }

        public static JsonSerializerOptions DefaultPostJsonOption
        {
            get; set;
        }
    }
}