using System;
using Backpack.Controller.Interfaces;
using Backpack.Definitions;
using Backpack.Model.Entities;
using Backpack.Model.Sources;
using Backpack.Model.Sources.Interfaces;

namespace Backpack.Controller
{
    public class BackpackController : IBackpackController<Item>
    {
        private readonly IDataSources<Item> _props = new ListDataSource(); // 道具
        private readonly IDataSources<Item> _materials = new ListDataSource(); // 材料
        private readonly IDataSources<Item> _fragment = new ListDataSource(); // 碎片
        private IDataSources<Item> _currentList;

        public BackpackController()
        {
            _currentList = _props;
        }

        public void SwitchDataSource(DataType type)
        {
            _currentList = GetSourceByType(type);

            // todo : 切换之后要重新通知长度
            // OnItemCountChanged?.Invoke(_currentList.Count);
        }

        public int dataSourceCount => _currentList.Count;

        public bool isEmpty => _currentList == null || _currentList.Count == 0;

        public void Add(Item item) => GetSourceByType(item.type).Add(item);

        public bool Remove(DataType type, int index) => GetSourceByType(type).Remove(index);

        public bool RemoveCurrent(int index) => _currentList.Remove(index);

        public Item Get(DataType type, int index) => GetSourceByType(type).Get(index);

        public Item GetCurrent(int index) => _currentList.Get(index);

        public bool Set(int index, Item item) => GetSourceByType(item.type).Set(index, item);

        private IDataSources<Item> GetSourceByType(DataType type) => type switch
        {
            DataType.Props => _props,
            DataType.Materials => _materials,
            DataType.Fragment => _fragment,
            _ => throw new ArgumentOutOfRangeException()
        };

        // todo : 缺乏总线控制和反馈
    }
}