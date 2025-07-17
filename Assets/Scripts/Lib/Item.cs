using System;
using UnityEngine;

namespace Lib
{
    [CreateAssetMenu(menuName = "Lib/Item", fileName = "New Item")]
    public sealed class Item : ScriptableObject, IComparable<Item>
    {
        public uint id;
        public EDataType type;
        public EQualityType quality;
        public Sprite icon; // 图标资源 (* icon:string  (图标资源)
        public uint amount; // 本格数量

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
    }

    public enum EDataType
    {
        [InspectorName("道具")] Props = 1,
        [InspectorName("材料")] Materials = 2,
        [InspectorName("碎片")] Fragment = 3
    }

    public enum EQualityType
    {
        [InspectorName("品质Ⅰ")] Quality1 = 1,
        [InspectorName("品质Ⅱ")] Quality2 = 2,
        [InspectorName("品质Ⅲ")] Quality3 = 3,
        [InspectorName("品质Ⅳ")] Quality4 = 4,
        [InspectorName("品质Ⅴ")] Quality5 = 5
    }
}