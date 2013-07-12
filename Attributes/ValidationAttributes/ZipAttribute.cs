using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class ZipAttribute : RegularExpressionAttribute
    {
        public ZipAttribute() : base(RegularExpressions.Validations.ZipRegex) { }
    }
}
