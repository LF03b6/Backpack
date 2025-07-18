using System;
using System.Collections.Generic;

namespace Core.ObjectPool
{
    public sealed class ObjectPool<T>
    {
        private readonly Stack<T> _pool = new();

        private readonly Func<T> _createFunc;

        public ObjectPool(Func<T> createFunc)
        {
            _createFunc = createFunc ?? throw new ArgumentNullException(nameof(createFunc),
                $"You must pass in a Func<T> type for {nameof(_createFunc)}");
        }

        public T GetItem()
        {
            return _pool.Count > 0 ? _pool.Pop() : _createFunc();
        }

        public void ReturnItem(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot return a null item to the pool.");
            }

            _pool.Push(item);
        }
    }
}