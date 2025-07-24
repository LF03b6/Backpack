using System;
using Core.ObjectPool;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Backpack.Provider
{
    [RequireComponent(typeof(LoopScrollRect))]
    [DisallowMultipleComponent]
    public class SlotsPoolProvider : MonoBehaviour, LoopScrollPrefabSource, LoopScrollDataSource
    {
        public GameObject item;
        public int defaultUiCount = -1;
        [SerializeField] private LoopScrollRect loopScrollRect;
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
            loopScrollRect ??= GetComponent<LoopScrollRect>();
            loopScrollRect.prefabSource = this;
            loopScrollRect.dataSource = this;
            loopScrollRect.totalCount = ProvideItemCount(defaultUiCount);
            loopScrollRect.RefillCells();
        }

        public void ReSizeUI()
        {
            var count = GameManager.instance.backpackController.dataSourceCount;
            loopScrollRect.totalCount = ProvideItemCount(count);
            loopScrollRect.RefreshCells();
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

        private static int ProvideItemCount(int countNow)
        {
            const int standardMax = Constants.BackpackConstants.SlotsCountStandard;
            const int standardRow = Constants.BackpackConstants.SlotsPerRow;

            return countNow > standardMax
                ? (countNow / standardRow + 1) * standardRow
                : standardMax;
        }
    }
}