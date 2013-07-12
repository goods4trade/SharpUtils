using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class DigitOnlyAttribute : RegularExpressionAttribute
    {
        public DigitOnlyAttribute() : base(RegularExpressions.Validations.DigitRuleRegex) { } 
    }
}