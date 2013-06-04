using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class PasswordRuleAttribute : RegularExpressionAttribute
    {
        public PasswordRuleAttribute() : base(RegularExpressions.Validations.PasswordRuleRegex) { }
    }
}