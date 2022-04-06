using System;

namespace Caomei.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ValidateFormItemOnlyAttribute : Attribute
    {
    }
}