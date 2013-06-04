using System.ComponentModel.DataAnnotations;

namespace SharpUtil.ValidationAttributes
{
    public class StateAttribute : RegularExpressionAttribute
    {
        public StateAttribute() : base(RegularExpressions.Validations.StateRegex) { }
    }
}
