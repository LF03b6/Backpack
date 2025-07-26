using Backpack.Constants;
using Backpack.Definitions;
using Backpack.Model.Entities;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Backpack.View
{
    public class ItemCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amount;
        [SerializeField] private TextMeshProUGUI quality;
        private Item _item;

        // private int _currentIndex = -1;
        private Controller.BackpackController _backpackController;

        private void Awake()
        {
            _backpackController = GameManager.instance.backpackController;
        }

        private void OnDisable()
        {
            // _currentIndex = -1;
            icon.enabled = false;
            amount.text = null;
            quality.text = null;
        }

        void ScrollCellIndex(int idx)
        {
            // 不变更或者空model
            // if (_currentIndex == idx ) return;
            // 越界 防止访问跃出model
            if (_backpackController.isEmpty || idx >= _backpackController.dataSourceCount)
            {
                icon.enabled = false;
                amount.text = null;
                quality.text = null;
                _item = null;
                return;
            }

            // 正常对应 重设引索
            // _currentIndex = idx;
            icon.enabled = true;

            // 获取item
            var item = _backpackController.GetCurrent(idx);
            _item = item;
            icon.sprite = item.icon;
            SetDescription(item.amount, item.quality);
        }

        private void SetDescription(int count, QualityType desc)
        {
            amount.text = count.ToString();
            switch (desc)
            {
                case QualityType.Quality1:
                    quality.text = "1";
                    quality.color = QualityConstants.L1;
                    break;
                case QualityType.Quality2:
                    quality.text = "2";
                    quality.color = QualityConstants.L2;
                    break;
                case QualityType.Quality3:
                    quality.text = "3";
                    quality.color = QualityConstants.L3;
                    break;
                case QualityType.Quality4:
                    quality.text = "4";
                    quality.color = QualityConstants.L4;
                    break;
                case QualityType.Quality5:
                default:
                    quality.text = "5";
                    quality.color = QualityConstants.L5;
                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_item == null) return;
            ItemDescription.instance.Show(_item); // 展示信息
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ItemDescription.instance.Hide();
        }
    }
}