using Backpack.Definitions;

namespace Backpack.Controller.Interfaces
{
    public interface IBackpackController<T>
    {
        public int dataSourceCount { get; }
        public bool isEmpty { get; }
        public void Add(T item);
        public bool Remove(DataType type, int index);
        public bool RemoveCurrent(int index);
        public T Get(DataType type, int index);
        public T GetCurrent(int index);
        public bool Set(int index, T item);
    }
}