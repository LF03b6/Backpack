using System;
using Config;
using Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Lib
{
    [RequireComponent(typeof(LoopScrollRect))]
    [DisallowMultipleComponent]
    public class SlotsPoolProvider : MonoBehaviour, LoopScrollPrefabSource, LoopScrollDataSource
    {
        public GameObject item;
        public int totalCount = -1;

        private ObjectPool<Transform> _slotsPool;

        private void Awake()
        {
            if (!item)
                throw new ArgumentNullException(nameof(item),
                    $"Field {nameof(item)} can't be null.");

            // 将对象池初始化移到Awake中，以便访问实例成员
            _slotsPool = new ObjectPool<Transform>(() => Instantiate(item).transform);
        }

        private void Start()
        {
            var ls = GetComponent<LoopScrollRect>();
            ls.prefabSource = this;
            ls.dataSource = this;
            ls.totalCount = totalCount;
            ls.RefillCells();

            // todo : 这里要添加默认初始化固定个数的slot
            // GameManager.instance.backpack.SetOnItemCountChanged(SetItemsCount);
            // private void SetItemsCount(int count)
            // {
            //     totalCount = count > GameConfig.Backpack.SlotsCountStandard
            //         ? (count / GameConfig.Backpack.SlotsPerRow + 1) * GameConfig.Backpack.SlotsPerRow
            //         : GameConfig.Backpack.SlotsCountStandard;
            // }
        }

        public GameObject GetObject(int index)
        {
            var thisItem = _slotsPool.GetItem().gameObject;
            thisItem.SetActive(true);
            return thisItem;
        }

        public void ReturnObject(Transform trans)
        {
            trans.SendMessage("ScrollCellReturn", SendMessageOptions.DontRequireReceiver);
            trans.SetParent(transform, false);
            trans.gameObject.SetActive(false);
            _slotsPool.ReturnItem(trans);
        }

        public void ProvideData(Transform trans, int idx)
        {
            trans.SendMessage("ScrollCellIndex", idx);
        }
    }
}