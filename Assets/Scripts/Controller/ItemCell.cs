using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class ItemCell : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amount;
        private int _currentIndex = -1;
        private Backpack _backpack;

        void ScrollCellIndex(int idx)
        {
            // 不变更或者空model
            if (_currentIndex == idx || _backpack.isEmpty) return;

            // 越界 防止访问跃出model
            if (idx >= _backpack.dataSourceCount)
            {
                icon.enabled = false;
                return;
            }

            // 正常对应 重设引索
            _currentIndex = idx;

            // 获取item
            var item = _backpack.GetAt(idx);
            icon.enabled = true;
            icon.sprite = item.icon;
            amount.text = item.amount.ToString();
        }

        private void OnEnable()
        {
            _backpack = GameManager.instance.backpack;
        }

        private void OnDisable()
        {
            _currentIndex = -1;
        }
    }
}