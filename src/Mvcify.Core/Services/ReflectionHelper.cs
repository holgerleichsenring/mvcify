﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mvcify.Core.Services
{
    public class ReflectionHelper
    {
        public PropertyInfo GetPropertyInfo<TSource, TProperty>(
            TSource source,
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof (TSource);

            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(
                    $"Expression '{propertyLambda}' refers to a method, not a property.");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(
                    $"Expression '{propertyLambda}' refers to a field, not a property.");

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(
                    $"Expresion '{propertyLambda}' refers to a property that is not from type {type}.");

            return propInfo;
        }
    }
}