using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IVoice.Helpers.Extensions
{
    public static class Extension
    {
        public static int ToInt(this string value, int defaultValue = 0)
        {
            int result = defaultValue;
            try { result = Convert.ToInt32(value.ToString()); }
            catch { }
            return result;
        }

        public static decimal ToDecimal(this string value, decimal defaultValue = 0)
        {
            decimal result = defaultValue;
            try { result = Convert.ToDecimal(value.ToString()); }
            catch { }
            return result;
        }

        

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters
                .Zip(second.Parameters, (f, s) => new { f, s })
                .ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static TValue GetElementOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            var result = default(TValue);
            dict.TryGetValue(key, out result);
            return result;
        }

        public static string ToRoute(this string value)
        {
            value = string.Concat(value.ToLower().Replace(" ", "-").Where(x => Char.IsLetterOrDigit(x) || x == '-').ToList());
            return value;
        }

        public static bool IsEmpty(this List<int> value)
        {
            if (value == null || value.Count == 0)
                return true;
            else if (value.Count == 1 && value.FirstOrDefault() == 0)
                return true;
            else return false;
        }

        public class ParameterRebinder : ExpressionVisitor
        {
            Dictionary<ParameterExpression, ParameterExpression> Map { get; }
            public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map) { Map = map; }

            protected override Expression VisitParameter(ParameterExpression p)
                => base.VisitParameter(Map.GetElementOrDefault(p) ?? p);

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression expression)
                => new ParameterRebinder(map).Visit(expression);
        }

        public static string Truncate(string value, int limit)
        {
            return value.Length <= limit ? value : value.Substring(0, limit) + "...";
        }

        public static string getElapsedTime(DateTime dt)
        {
            var timespan = DateTime.Now - dt;
            string res = "";

            if (timespan.TotalDays >= 1)
                res = timespan.TotalDays.ToString("#,##0") + " days ago";
            else if (timespan.TotalHours >= 1)
                res = timespan.TotalHours.ToString("#,##0") + " hours ago";
            else if (timespan.TotalMinutes >= 1)
                res = timespan.TotalMinutes.ToString("#,##0") + " minutes ago";
            else
                res = timespan.TotalSeconds.ToString("#,##0") + " seconds ago";

            return res;
        }
    }
}
