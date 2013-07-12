using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class FullNameAttribute : RegularExpressionAttribute
    {
        public FullNameAttribute() : base(RegularExpressions.Validations.FullNameRegex) { } 
    }
}