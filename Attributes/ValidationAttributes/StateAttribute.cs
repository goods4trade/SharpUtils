using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class StateAttribute : RegularExpressionAttribute
    {
        public StateAttribute() : base(RegularExpressions.Validations.StateRegex) { }
    }
}
