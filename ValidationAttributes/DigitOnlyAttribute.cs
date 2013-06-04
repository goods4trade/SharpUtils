using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class DigitOnlyAttribute : RegularExpressionAttribute
    {
        public DigitOnlyAttribute() : base(RegularExpressions.Validations.DigitRuleRegex) { }
    }
}