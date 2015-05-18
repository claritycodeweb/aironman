using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using System.Data.Entity;

using AIronMan.DataSource;

namespace AIronMan.Repository {
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class {

        protected DB Context = null;

        public Repository() {
            Context = new DB();
        }

        public Repository(DB context) {
            Context = context;
        }

        protected DbSet<TEntity> DbSet {
            get {
                return Context.Set<TEntity>();
            }
        }

        public virtual IQueryable<TEntity> All() {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate) {
            return DbSet.Where(predicate).AsQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50) {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate) {
            return DbSet.Count(predicate) > 0;
        }

        public virtual TEntity Find(params object[] keys) {
            return DbSet.Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate) {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TEntity Create(TEntity TObject) {
            var newEntry = DbSet.Add(TObject);
            //if (!shareContext)
             //   Context.SaveChanges();
            return newEntry;
        }

        public virtual int Count {
            get {
                return DbSet.Count();
            }
        }

        public virtual int Delete(TEntity TObject) {
            DbSet.Remove(TObject);
            //if (!shareContext)
             //   return Context.SaveChanges();
            return 0;
        }

        public virtual int Update(TEntity TObject) {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            //if (!shareContext)
             //   return Context.SaveChanges();
            return 0;
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate) {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
           // if (!shareContext)
            //    return Context.SaveChanges();
            return 0;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters) {
            return DbSet.SqlQuery(query, parameters).ToList();
        }

        public void Dispose() {
            if (Context != null)
                Context.Dispose();
        }
    }
}
