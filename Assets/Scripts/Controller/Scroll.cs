using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class Scroll : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amount;
        private int _indexInData = -1;

        void ScrollCellIndex(int idx)
        {
            if (_indexInData == idx) return;

            var list = GameManager.instance.backpackManager.currentList;

            if (list == null) return;
            
            if (idx >= list.Count)
            {
                icon.enabled = false;
                return;
            }

            _indexInData = idx;

            var item = list[idx];
            icon.sprite = item.icon;
            amount.text = item.amount.ToString();
        }
    }
}