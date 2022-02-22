using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaPlace.BL.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> Items { get; }

        T Get(int id);

        Task<T> GetAsync(int id, CancellationToken cancel = default);

        T Add(int id);

        Task<T> AddAsync(int id, CancellationToken cancel = default);

        void Update(int id);

        Task UpdateAsync(int id, CancellationToken cancel = default);

        void Remove(int id);

        Task RemoveAsync(int id, CancellationToken cancel = default);
    }
}
