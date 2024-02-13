using System.Linq.Expressions;

namespace SampleWebAPI.Models
{
    public static class QueryableExtensions
    {
        //Extenstion Classes are static classes, that helps us define static methods to the existing types 
        //without modifing them.
        //Extenstion methods should be static and have this keyword in the parameter 
        public static IQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> items, string sortBy, string sortOrder)
        {
            var type = typeof(TEntity);
            var expression2 = Expression.Parameter(type, "t");
            var property = type.GetProperty(sortBy);
            if (property == null) { throw new ArgumentException($"property {sortBy} is null", sortBy); }
            var expression1 = Expression.MakeMemberAccess(expression2, property);
            var lambda = Expression.Lambda(expression1, expression2);
            var result = Expression.Call(
                typeof(Queryable),
                sortOrder == "desc" ? "OrderByDescending" : "OrderBy",
                new Type[] { type, property.PropertyType },
                items.Expression,
                Expression.Quote(lambda));

            return items.Provider.CreateQuery<TEntity>(result);
        }
    }
}
