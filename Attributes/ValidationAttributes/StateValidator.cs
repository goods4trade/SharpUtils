using System.Collections.Generic;
using System.Web.Mvc;

namespace MAXX.Utils.Attributes.ValidationAttributes
{
    public class StateValidator : DataAnnotationsModelValidator<StateAttribute>
    {
        #region Fields

        private readonly string _errorMessage;
        private readonly string _pattern;

        #endregion Fields

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValidator"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <param name="attribute">The attribute.</param>
        public StateValidator(ModelMetadata metadata, ControllerContext context, StateAttribute attribute) : base(metadata, context, attribute)
        {
            this._errorMessage = attribute.ErrorMessage;
            this._pattern = attribute.Pattern;
        }

        #endregion Ctors

        #region Methods

        /// <summary>
        /// Retrieves a collection of client validation rules.
        /// </summary>
        /// <returns>A collection of client validation rules.</returns>
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRegexRule(this._errorMessage, this._pattern);
            return new[] { rule };
        }

        #endregion Methods
    }
}
