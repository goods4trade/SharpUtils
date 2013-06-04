using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class PasswordRuleAttribute : RegularExpressionAttribute
    {
        public PasswordRuleAttribute() : base(RegularExpressions.Validations.PasswordRuleRegex) { }
    }
}