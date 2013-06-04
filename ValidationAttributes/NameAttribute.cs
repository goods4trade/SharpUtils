using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class NameAttribute : RegularExpressionAttribute
    {
        public NameAttribute() : base(RegularExpressions.Validations.NameRegex) { }
    }
}
