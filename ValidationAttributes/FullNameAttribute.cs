using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class FullNameAttribute : RegularExpressionAttribute
    {
        public FullNameAttribute() : base(RegularExpressions.Validations.FullNameRegex) { }
    }
}