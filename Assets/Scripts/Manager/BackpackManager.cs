using System;
using System.Collections.Generic;
using Lib;
using Model;
using UnityEngine.UI;

namespace Manager
{
    public class BackpackManager
    {
        private readonly IDataSources<Item> _props = new ListDataSource(); // 道具
        private readonly IDataSources<Item> _materials = new ListDataSource(); // 材料
        private readonly IDataSources<Item> _fragment = new ListDataSource(); // 碎片

        public IDataSources<Item> currentList { get; private set; }
        private event Action<int> OnItemCountChanged;

        public void ResetSelectionType(ESelectionType selectionType)
        {
            currentList = selectionType switch
            {
                ESelectionType.Props => _props,
                ESelectionType.Materials => _materials,
                ESelectionType.Fragment => _fragment,
                _ => throw new ArgumentOutOfRangeException(nameof(selectionType), selectionType, null)
            };

            OnItemCountChanged?.Invoke(currentList.Count);
        }

        private bool _hasSet;

        public void SetOnItemCountChanged(Action<int> onItemCountChanged)
        {
            OnItemCountChanged += onItemCountChanged;
            if (_hasSet) return;
            _props.OnItemCountChanged += onItemCountChanged;
            _materials.OnItemCountChanged += onItemCountChanged;
            _fragment.OnItemCountChanged += onItemCountChanged;
            _hasSet = true;
        }

        public void AddItem(Item item)
        {
            switch (item.type)
            {
                case ESelectionType.Props:
                    _props.Add(item);
                    break;
                case ESelectionType.Materials:
                    _materials.Add(item);
                    break;
                case ESelectionType.Fragment:
                    _fragment.Add(item);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnOpen()
        {
            currentList = _props;
        }
    }
}