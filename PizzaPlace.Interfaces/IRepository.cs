using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    /// <summary>Base interface for working with Db</summary>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>Entries in Db</summary>
        IQueryable<T> Items { get; }

        /// <summary>Get item from Db</summary>
        /// <returns>Taken item</returns>
        T Get(int id);

        /// <summary>Get item from Db</summary>
        /// <returns>Taken item</returns>
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        /// <summary>Add item to Db</summary>
        /// <param name="item">Current item</param>
        /// <returns>Adding item</returns>
        T Add(T item);

        /// <summary>Add item to Db</summary>
        /// <param name="item">Current item</param>
        /// <returns>Adding item</returns>
        Task<T> AddAsync(T item, CancellationToken cancel = default);

        /// <summary>Refresh entries in Db</summary>
        /// <param name="item">Current item</param>
        void Update(T item);

        /// <summary>Refresh entries in Db</summary>
        /// <param name="item">Current item</param>
        Task UpdateAsync(T item, CancellationToken cancel = default);

        /// <summary>Delete item from Db</summary>
        void Remove(int id);

        /// <summary>Delete item from Db</summary>
        Task RemoveAsync(int id, CancellationToken cancel = default);
    }
}
