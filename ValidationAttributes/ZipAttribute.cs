using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class ZipAttribute : RegularExpressionAttribute
    {
        public ZipAttribute() : base(RegularExpressions.Validations.ZipRegex) { }
    }
}
