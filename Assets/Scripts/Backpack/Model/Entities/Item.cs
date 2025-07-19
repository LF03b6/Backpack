using System;
using Backpack.Definitions;
using UnityEngine;

namespace Backpack.Model.Entities
{
    public sealed class Item : IComparable<Item>
    {
        public uint id { get; }
        public DataType type { get; }
        public QualityType quality { get; }
        public Sprite icon { get; } // 图标资源 (* icon:string  (图标资源)
        public int amount { get; private set; } // 本格数量

        public Item(uint id, DataType type, QualityType quality, Sprite icon, int amount)
        {
            this.id = id;
            this.type = type;
            this.quality = quality;
            this.icon = icon;
            this.amount = amount;
        }

        public Item(global::Model.Entities.Item item)
        {
            id = item.id;
            type = item.type;
            quality = item.quality;
            icon = item.icon;
            amount = 1;
        }

        public int CompareTo(Item other)
        {
            // 如果 other 是 null，则当前对象大于 null 对象
            if (other == null) return 1;

            // 品质从高到低
            var qualityComparison = quality.CompareTo(other.quality);
            if (qualityComparison != 0) return qualityComparison;

            // 类型从小到大
            var typeComparison = type.CompareTo(other.type);
            if (typeComparison != 0) return typeComparison;

            // id从小到大
            var idComparison = id.CompareTo(other.id);
            if (idComparison != 0) return idComparison;

            // amount从大到小
            return amount.CompareTo(other.amount);
        }

        public void ReAmount(int increment)
        {
            var t = amount + increment;
            if (t <= 0)
            {
                t = 0;
                // todo : resize
            }

            amount = t;
        }
    }
}