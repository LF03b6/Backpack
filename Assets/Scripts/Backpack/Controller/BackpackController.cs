using System;
using Backpack.Controller.Interfaces;
using Backpack.Definitions;
using Backpack.Model.Entities;
using Backpack.Model.Sources;
using Backpack.Model.Sources.Interfaces;
using Backpack.Provider;
using UnityEngine;

namespace Backpack.Controller
{
    public class BackpackController : IBackpackController<Item>
    {
        private readonly IDataSources<Item> _props = new ListDataSource(); // 道具
        private readonly IDataSources<Item> _materials = new ListDataSource(); // 材料
        private readonly IDataSources<Item> _fragment = new ListDataSource(); // 碎片
        private IDataSources<Item> _currentList;
        private SlotsPoolProvider _provider;

        public BackpackController(SlotsPoolProvider vm)
        {
            if (vm == null)
            {
                Debug.LogError("BackpackController: vm is null");
            }

            _currentList = _props;
            _provider = vm;
        }

        public void SwitchDataSource(DataType type)
        {
            _currentList = GetSourceByType(type);
            _provider?.ReSizeUI();
        }

        public int dataSourceCount => _currentList.Count;

        public bool isEmpty => _currentList == null || _currentList.Count == 0;

        public void Add(Item item)
        {
            GetSourceByType(item.type).Add(item);
            _provider.ReSizeUI();
        }

        public bool Remove(DataType type, int index)
        {
            var res = GetSourceByType(type).Remove(index);
            _provider.ReSizeUI();
            return res;
        }

        public bool RemoveCurrent(int index)
        {
            var res = _currentList.Remove(index);
            _provider.ReSizeUI();
            return res;
        }

        public Item Get(DataType type, int index)
        {
            var res = GetSourceByType(type).Get(index);
            return res;
        }

        public Item GetCurrent(int index)
        {
            var res = _currentList.Get(index);
            return res;
        }

        public bool Set(int index, Item item)
        {
            var res = GetSourceByType(item.type).Set(index, item);
            _provider.ReSizeUI();
            return res;
        }

        public void ReSizeUI()
        {
            _provider.ReSizeUI();
        }

        private IDataSources<Item> GetSourceByType(DataType type) => type switch
        {
            DataType.Props => _props,
            DataType.Materials => _materials,
            DataType.Fragment => _fragment,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}