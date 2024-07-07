using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;

namespace api.Helpers
{
    public static class SoftDeleteHelper
    {
        public static void SoftDelete<TEntity>(ApplicationDBContext context, int id) where TEntity : class
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                if (entity is ISoftDelete softDeleteEntity)
                {
                    softDeleteEntity.IsDeleted = true;
                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException($"Entity {typeof(TEntity)} does not support soft delete.");
                }
            }
        }
    }

}