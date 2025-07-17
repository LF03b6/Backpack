using System.Collections.Generic;

namespace Model
{
    public interface IDataSources<T> : ICollection<T>
    {
        void Insert(int index, T item);
        T this[int index] { get; }
    }
}