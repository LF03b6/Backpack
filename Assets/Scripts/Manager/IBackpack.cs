using Lib;

namespace Manager
{
    public interface IBackpack<T>
    {
        public int dataSourceCount { get; }
        public bool isEmpty { get; }
        public void Add(EDataType type,T item);
        public void AddCurrent(T item);
        public bool RemoveAt(int index);
        public T GetAt(int index);
        public bool SetAt(int index, T item);
    }
}