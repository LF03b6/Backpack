using System;
using Lib;
using Manager;
using Model;

namespace Controller
{
    public class Backpack : IBackpack<Item>
    {
        private readonly IDataSources<Item> _props = new ListDataSource(); // 道具
        private readonly IDataSources<Item> _materials = new ListDataSource(); // 材料
        private readonly IDataSources<Item> _fragment = new ListDataSource(); // 碎片
        private IDataSources<Item> _currentList;

        public int dataSourceCount => _currentList.Count;
        public bool isEmpty => _currentList == null || _currentList.Count == 0;
        public bool IsReadOnly = false;

        public void SwitchDataSource(EDataType type)
        {
            _currentList = GetByDataType(type);

            // todo : 切换之后要重新通知长度
            // OnItemCountChanged?.Invoke(_currentList.Count);
        }

        public void Add(EDataType type, Item item)
        {
            GetByDataType(type).Add(item);
        }

        public void AddCurrent(Item item)
        {
            _currentList.Add(item);
        }

        public bool RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Item GetAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool SetAt(int index, Item item)
        {
            throw new NotImplementedException();
        }

        private IDataSources<Item> GetByDataType(EDataType type) => type switch
        {
            EDataType.Props => _props,
            EDataType.Materials => _materials,
            EDataType.Fragment => _fragment,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}