namespace MyAttribute.ValidateExtend
{
    public class RequiredAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object oValue)
        {
            return oValue != null
                && !string.IsNullOrWhiteSpace(oValue.ToString());
        }
    }
}
