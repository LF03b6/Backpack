using System;
using Backpack.Definitions;
using UnityEngine;

namespace Model.Entities
{
    [CreateAssetMenu(menuName = "Lib/Item", fileName = "New Item")]
    public sealed class Item : ScriptableObject
    {
        public uint id;
        public DataType type;
        public QualityType quality;
        public Sprite icon; // 图标资源 (* icon:string  (图标资源)
    }
}