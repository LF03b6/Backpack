using System.Collections.Generic;

namespace Backpack.Model.Sources.Interfaces
{
    public interface IDataSources<T> : ICollection<T>
    {
        T Get(int index);
        bool Set(int index, T item);
        void Insert(int index, T item);
        bool Remove(int index);
    }
}