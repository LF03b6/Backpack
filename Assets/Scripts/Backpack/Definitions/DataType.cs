using System;
using UnityEngine;

namespace Backpack.Definitions
{
    [Serializable]
    public enum DataType
    {
        [InspectorName("道具")] Props = 1,
        [InspectorName("材料")] Materials = 2,
        [InspectorName("碎片")] Fragment = 3
    }
}