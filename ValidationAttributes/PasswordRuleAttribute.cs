using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class PasswordRuleAttribute : RegularExpressionAttribute
    {
        public PasswordRuleAttribute() : base(RegularExpressions.Validations.PasswordRuleRegex) { }
    }
}