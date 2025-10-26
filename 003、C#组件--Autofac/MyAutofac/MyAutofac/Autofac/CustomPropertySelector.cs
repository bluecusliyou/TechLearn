using Autofac.Core;
using System.Linq;
using System.Reflection;

namespace MyAutofac
{
    public class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            var flag = propertyInfo.CustomAttributes.Any(it => it.AttributeType == typeof(SelectPropAttribute));
            return flag;
        }
    }
}
