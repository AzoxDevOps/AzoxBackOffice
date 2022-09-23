namespace Azox.Core.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    public static class ExpressionExtensions
    {
        public static string Simplify<T>(this Expression<T> expression)
        {
            return Simplify((Expression)expression);
        }

        public static string Simplify(this Expression expression)
        {
            ParameterlessExpressionSearcher searcher = new();
            searcher.Visit(expression);

            ParameterlessExpressionEvaluator evaluator = new(searcher.ParameterlessExpressions);
            Expression? e = evaluator.Visit(expression);

            return e == null ? null : e.ToString();
        }

        #region Nested

        private class ParameterlessExpressionSearcher :
            ExpressionVisitor
        {
            #region Fields

            private bool _containsParameter = false;

            #endregion Fields

            #region Ctor

            public ParameterlessExpressionSearcher()
            {
                ParameterlessExpressions = new();
            }

            #endregion Ctor

            #region Methods

            [return: NotNullIfNotNull("node")]
            public override Expression? Visit(Expression? node)
            {
                bool originalContainsParameter = _containsParameter;
                _containsParameter = false;
                base.Visit(node);

                if (!_containsParameter)
                {
                    if (node?.NodeType == ExpressionType.Parameter)
                    {
                        _containsParameter = true;
                    }
                    else
                    {
                        ParameterlessExpressions.Add(node);
                    }
                }

                _containsParameter |= originalContainsParameter;

                return node;
            }

            #endregion Methods

            #region Properties

            public HashSet<Expression> ParameterlessExpressions { get; }

            #endregion Properties
        }

        private class ParameterlessExpressionEvaluator :
            ExpressionVisitor
        {
            #region Fields

            private readonly HashSet<Expression> _parameterlessExpressions;

            #endregion Fields

            #region Ctor

            public ParameterlessExpressionEvaluator(HashSet<Expression> parameterlessExpressions)
            {
                _parameterlessExpressions = parameterlessExpressions;
            }

            #endregion Ctor

            #region Utils

            [return: NotNullIfNotNull("node")]
            private Expression? Evaluate(Expression? node)
            {
                if (node == null)
                {
                    return node;
                }

                if (node.NodeType == ExpressionType.Constant)
                {
                    return node;
                }

                object value = Expression.Lambda(node).Compile().DynamicInvoke();
                return Expression.Constant(value, node.Type);
            }

            #endregion Utils

            #region Methods

            [return: NotNullIfNotNull("node")]
            public override Expression? Visit(Expression? node)
            {
                if (_parameterlessExpressions.Contains(node))
                {
                    return Evaluate(node);
                }
                return base.Visit(node);
            }

            #endregion Methods
        }

        #endregion Nested
    }
}
