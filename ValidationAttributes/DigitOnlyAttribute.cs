using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class DigitOnlyAttribute : RegularExpressionAttribute
    {
        public DigitOnlyAttribute() : base(RegularExpressions.Validations.DigitRuleRegex) { }
    }
}