using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MAXX.Utils.Helpers
{
    public static class Models
    {
        public static string GetDisplayName<TModel, TProperty>(this TModel model, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression)
        {
            return ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, new ViewDataDictionary<TModel>(model)).DisplayName;
        }

        public static bool IsRequired<TModel, TProperty>(this TModel model, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression)
        {
            return ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, new ViewDataDictionary<TModel>(model)).IsRequired;
        }

        public static int? GetMaxLength<TModel, TProperty>(this TModel model, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression)
        {
            int? maxLength = null;
            var attributes = new Dictionary<string, Object>();
            var memberAccessExpression = (MemberExpression)expression.Body;
            var maxLengthAttr = memberAccessExpression.Member.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute), true);

            if (maxLengthAttr.Length > 0)
            {
                maxLength = ((StringLengthAttribute)maxLengthAttr[0]).MaximumLength;
            }
            else
            {
                maxLengthAttr = memberAccessExpression.Member.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute), true);
                if (maxLengthAttr.Length > 0)
                {
                    maxLength = ((MaxLengthAttribute)maxLengthAttr[0]).Length;
                }
            }

            return maxLength;
        }

    }
}
