using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class NameAttribute : RegularExpressionAttribute
    {
        public NameAttribute() : base(RegularExpressions.Validations.NameRegex) { }
    }
}
