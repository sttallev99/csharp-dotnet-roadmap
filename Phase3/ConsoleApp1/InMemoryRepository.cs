using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InMemoryRepository<T> where T : class, IEntity
    {
        private readonly Dictionary<int, T> _items = new Dictionary<int, T>();
        private int _nextId = 1;

        public int Count => _items.Count;

        public T Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            item.Id = _nextId++;
            _items.Add(item.Id, item);
            return item;
        }

        public T? GetById(int id) => _items.GetValueOrDefault(id);

        public IReadOnlyList<T> GetAll() =>
            _items.Values.OrderBy(x => x.Id).ToList();


        public IReadOnlyList<T> Find(Func<T, bool> match)
        {
            ArgumentNullException.ThrowIfNull(match);
            return _items.Values.Where(match).OrderBy(x => x.Id).ToList();
        }

        public bool Remove(int id) => _items.Remove(id);
    }
}
