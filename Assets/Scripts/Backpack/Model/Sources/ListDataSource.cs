using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Backpack.Constants;
using Backpack.Model.Entities;
using Backpack.Model.Sources.Interfaces;
using UnityEngine;

namespace Backpack.Model.Sources
{
    public sealed class ListDataSource : IDataSources<Item>
    {
        private readonly List<Item> _items = new();
        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public Item Get(int index)
        {
            return _items[index];
        }

        public bool Remove(int index)
        {
            _items.RemoveAt(index);
            _items.Sort();
            return true;
        }

        public void Insert(int index, Item item)
        {
            _items.Insert(index, item);
            _items.Sort();
        }

        public bool Set(int index, Item item)
        {
            _items[index] = item;
            return true;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            if (item is not { amount: > 0 }) return;

            var remaining = item.amount;

            // 查找所有可叠加的 item（未满格的）
            var matches = _items
                .Where(i => i.id == item.id && i.type == item.type && i.amount < BackpackConstants.SlotMaxAmount)
                .ToList();

            foreach (var result in matches.Select(existing => existing.ReAmount(remaining)))
            {
                if (result == null)
                {
                    // 完全叠加成功，无剩余
                    remaining = 0;
                    break;
                }

                if (result <= 0)
                {
                    // 不太可能出现 <= 0 的情况，但为了健壮性处理一下
                    remaining = 0;
                    break;
                }

                remaining = result.Value;
            }

            // 如果还有剩余，说明需要开新容器（可能多个）
            while (remaining > 0)
            {
                var addAmount = Math.Min(remaining, BackpackConstants.SlotMaxAmount);
                _items.Add(new Item(
                    item.id,
                    item.type,
                    item.quality,
                    item.icon,
                    addAmount
                ));
                remaining -= addAmount;
            }
            
            _items.Sort();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            var res = _items.Remove(item);
            _items.Sort();
            return res;
        }
    }
}