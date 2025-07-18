using Backpack.Definitions;

namespace Backpack.Controller.Interfaces
{
    public interface IBackpackController<T>
    {
        public int dataSourceCount { get; }
        public bool isEmpty { get; }
        public void Add(DataType type, T item);
        public void AddCurrent(T item);
        public bool Remove(DataType type, int index);
        public bool RemoveCurrent(int index);
        public T Get(DataType type, int index);
        public T GetCurrent(int index);
        public bool Set(DataType type, int index, T item);
        public bool SetCurrent(int index, T item);
    }
}