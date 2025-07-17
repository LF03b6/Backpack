using System;
using System.Collections.Generic;

namespace Model
{
    public interface IDataSources<T> : ICollection<T>
    {
        public event Action<int> OnItemCountChanged;
        void Insert(int index, T item);
        T this[int index] { get; }
    }
}