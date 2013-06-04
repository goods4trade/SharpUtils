using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class ZipAttribute : RegularExpressionAttribute
    {
        public ZipAttribute() : base(RegularExpressions.Validations.ZipRegex) { }
    }
}
