using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class FullNameAttribute : RegularExpressionAttribute
    {
        public FullNameAttribute() : base(RegularExpressions.Validations.FullNameRegex) { }
    }
}