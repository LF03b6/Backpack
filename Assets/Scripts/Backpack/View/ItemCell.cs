using System;
using Backpack.Constants;
using Backpack.Definitions;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Backpack.View
{
    public class ItemCell : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amount;
        [SerializeField] private TextMeshProUGUI quality;
        private int _currentIndex = -1;
        private Controller.BackpackController _backpackController;

        private void OnEnable()
        {
            _backpackController = GameManager.instance.backpackController;
        }

        private void OnDisable()
        {
            _currentIndex = -1;
            icon.enabled = false;
            amount.text = null;
            quality.text = null;
        }

        void ScrollCellIndex(int idx)
        {
            // 不变更或者空model
            if (_currentIndex == idx || _backpackController.isEmpty) return;

            // 越界 防止访问跃出model
            if (idx >= _backpackController.dataSourceCount) return;

            // 正常对应 重设引索
            _currentIndex = idx;
            icon.enabled = true;
            
            // 获取item
            var item = _backpackController.GetCurrent(idx);
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
    }
}