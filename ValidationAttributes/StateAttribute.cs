using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.ValidationAttributes
{
    public class StateAttribute : RegularExpressionAttribute
    {
        public StateAttribute() : base(RegularExpressions.Validations.StateRegex) { }
    }
}
