using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class NameAttribute : RegularExpressionAttribute
    {
        public NameAttribute() : base(RegularExpressions.Validations.NameRegex) { }
    }
}
