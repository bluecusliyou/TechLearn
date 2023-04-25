using System;

namespace MyAttribute.ValidateExtend
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
