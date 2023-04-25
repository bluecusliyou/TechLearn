using System;

namespace MyAttribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LongAttribute : AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;
        public LongAttribute(long min, long max)
        {
            this._Min = min;
            this._Max = max;
        }

        public override bool Validate(object oValue)
        {
            return oValue != null
                && long.TryParse(oValue.ToString(), out long lValue)
                && lValue >= this._Min
                && lValue <= this._Max;
        }
    }
}
