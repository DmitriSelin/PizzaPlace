using Microsoft.EntityFrameworkCore;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Context;
using PizzaPlaceDB.DAL.Entities.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaPlaceDB.DAL
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly PizzaPlaceContext db;
        private readonly DbSet<T> set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(PizzaPlaceContext dbContext)
        {
            db = dbContext;
            set = dbContext.Set<T>();
        }

        public virtual IQueryable<T> Items => set;

        public T Get(int id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }

        public async Task<T> GetAsync(int id, CancellationToken cancel = default)
        {
            return await Items.SingleOrDefaultAsync(item => item.Id == id, cancel)
                              .ConfigureAwait(false);
        }

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            db.Entry(item).State = EntityState.Added;

            if (AutoSaveChanges)
            db.SaveChanges();

            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            //db.Entry(item).Context.Add(item);
            db.Entry(item).State = EntityState.Added;

            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);

            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            db.Entry(item).State = EntityState.Modified;

            if (AutoSaveChanges)
                db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            db.Entry(item).State = EntityState.Modified;

            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public void Remove(int id)
        {
            db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}