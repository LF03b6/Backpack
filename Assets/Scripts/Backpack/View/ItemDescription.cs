using System;
using Backpack.Definitions;
using Backpack.Model.Entities;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Backpack.View
{
    public class ItemDescription : MonoBehaviour
    {
        private static ItemDescription _instance;

        public static ItemDescription instance
        {
            get
            {
                if (_instance != null) return _instance;
                // 查找场景中已存在的实例（即使 inactive）
                _instance = FindObjectOfType<ItemDescription>(true); // true 表示包含 inactive 物体
                if (_instance == null)
                {
                    Debug.LogError("未找到 ItemDescription 实例！");
                }
                else
                {
                    _instance.ManualInit(); // 显式初始化
                }

                return _instance;
            }
        }

        private bool _isInitialized;

        // 手动初始化方法（替代 Awake）
        private void ManualInit()
        {
            if (_isInitialized) return;
            _isInitialized = true;
        }


        [SerializeField] private Vector2 offset;
        [SerializeField] private RectTransform tooltipUI; // 指向你的悬浮UI物体
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI id;
        [SerializeField] private TextMeshProUGUI type;
        [SerializeField] private TextMeshProUGUI quantity;
        [SerializeField] private TextMeshProUGUI count;

        private void LateUpdate()
        {
            if (!tooltipUI.gameObject.activeSelf) return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                tooltipUI.parent as RectTransform,
                Input.mousePosition,
                null, // 或者你的 Canvas 的 camera
                out var mousePos
            );
            tooltipUI.anchoredPosition = mousePos + offset;
        }

        public void Show(Item item)
        {
            tooltipUI.gameObject.SetActive(true);
            icon.sprite = item.icon;
            id.text = item.id.ToString();
            type.text = item.type.ToString();
            quantity.text = item.quality.ToString();
            count.text = item.amount.ToString();
        }

        public void Hide()
        {
            tooltipUI.gameObject.SetActive(false);
        }
    }
}