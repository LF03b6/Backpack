using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public sealed class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Button button;

        private void Awake()
        {
            if (!panel)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log($"Close button clicked: {panel}");
        }
    }
}