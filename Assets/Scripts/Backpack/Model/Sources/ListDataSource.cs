using System.Collections;
using System.Collections.Generic;
using Backpack.Model.Entities;
using Backpack.Model.Sources.Interfaces;

namespace Backpack.Model.Sources
{
    public sealed class ListDataSource : IDataSources<Item>
    {
        private readonly List<Item> _items = new();
        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public Item Get(int index)
        {
            return _items[index];
        }

        public bool Remove(int index)
        {
            _items.RemoveAt(index);
            return true;
        }

        public void Insert(int index, Item item)
        {
            _items.Insert(index, item);
        }

        public bool Set(int index, Item item)
        {
            _items[index] = item;
            return true;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            var res = _items.Remove(item);
            return res;
        }
    }
}