using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class NameAttribute : RegularExpressionAttribute
    {
        public NameAttribute() : base(RegularExpressions.Validations.NameRegex) { }
    }
}
