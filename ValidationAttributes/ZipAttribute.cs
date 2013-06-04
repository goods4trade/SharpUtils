using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class ZipAttribute : RegularExpressionAttribute
    {
        public ZipAttribute() : base(RegularExpressions.Validations.ZipRegex) { }
    }
}
