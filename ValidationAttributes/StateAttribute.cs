using System.ComponentModel.DataAnnotations;

namespace SharpUtils.ValidationAttributes
{
    public class StateAttribute : RegularExpressionAttribute
    {
        public StateAttribute() : base(RegularExpressions.Validations.StateRegex) { }
    }
}
