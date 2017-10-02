using System;
using System.Linq.Expressions;

namespace LMB.PredicateBuilderExtension
{
    /// <summary>
    /// Enables the efficient, dynamic composition of query predicates.
    /// </summary>
    public static class PredicateBuilderExtension
    {
        /// <summary>
        /// Combines the first expression with the second using the specified merge function.
        /// </summary>
        internal class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }

        /// <summary>
        /// Creates a predicate that evaluates to true.
        /// </summary>
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        /// <summary>
        /// Creates a predicate that evaluates to false.
        /// </summary>
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        /// <summary>
        /// Combines the first predicate with the second using the logical "and".
        /// </summary>
        /// <typeparam name="T">
        /// The type of the parameter of the method that this delegate encapsulates.
        /// </typeparam>
        /// <param name="expr1">Represents a strongly typed lambda expression as a data structure in the form of an expression tree.</param>
        /// <param name="expr2">Represents a strongly typed lambda expression as a data structure in the form of an expression tree.</param>
        /// <returns>
        /// The strongly typed lambda expression that combines the first predicate with the second using the logical "and".
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "or".
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="expr1">Represents a strongly typed lambda expression as a data structure in the form of an expression tree.</param>
        /// <param name="expr2">Represents a strongly typed lambda expression as a data structure in the form of an expression tree.</param>
        /// <returns>
        /// The strongly typed lambda expression that combines the first predicate with the second using the logical "or".
        /// </returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), parameter);
        }

        /// <summary>
        /// Negates the predicate.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="expression">Represents a strongly typed lambda expression as a data structure in the form of an expression tree.</param>
        /// <returns>
        /// The strongly typed lambda expression that negates the predicate.
        /// </returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }
    }
}
