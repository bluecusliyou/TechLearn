using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }

    public class LongValidateAttribute : AbstractValidateAttribute
    {
        private long _lMin = 0;
        private long _lMax = 0;
        public LongValidateAttribute(long lMin, long lMax)
        {
            this._lMin = lMin;
            this._lMax = lMax;
        }

        public override bool Validate(object oValue)
        {
            return this._lMin < (long)oValue && (long)oValue < this._lMax;
        }
    }
    public class RequirdValidateAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object oValue)
        {
            return oValue != null;
        }
    }

    public class DataValidate
    {
        public static bool Validate<T>(T t)
        {
            Type type = t.GetType();
            bool result = true;
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object item = prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true)[0];
                    AbstractValidateAttribute attribute = item as AbstractValidateAttribute;
                    if (!attribute.Validate(prop.GetValue(t)))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
