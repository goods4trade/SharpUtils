using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class DigitOnlyAttribute : RegularExpressionAttribute
    {
        public DigitOnlyAttribute() : base(RegularExpressions.Validations.DigitRuleRegex) { } 
    }
}