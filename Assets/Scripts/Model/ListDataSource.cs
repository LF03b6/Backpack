using System;
using System.Collections;
using System.Collections.Generic;
using Lib;

namespace Model
{
    public sealed class ListDataSource : IDataSources<Item>
    {
        private readonly List<Item> _items = new();
        public event Action<int> OnItemCountChanged;
        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public void Insert(int index, Item item)
        {
            _items.Insert(index, item);
            OnItemCountChanged?.Invoke(_items.Count);
        }

        public Item this[int index] => _items[index];

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
            OnItemCountChanged?.Invoke(_items.Count);
        }

        public void Clear()
        {
            _items.Clear();
            OnItemCountChanged?.Invoke(_items.Count);
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
            OnItemCountChanged?.Invoke(_items.Count);
            return res;
        }
    }
}