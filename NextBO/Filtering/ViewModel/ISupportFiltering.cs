using System;
using System.Linq.Expressions;

namespace NextBO.Wpf.ViewModels {
    public interface ISupportFiltering<TEntity> where TEntity : class {
        Expression<Func<TEntity, bool>> FilterExpression { get; set; }
    }
}