using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class FullNameAttribute : RegularExpressionAttribute
    {
        public FullNameAttribute() : base(RegularExpressions.Validations.FullNameRegex) { } 
    }
}