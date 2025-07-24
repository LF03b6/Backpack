using UnityEngine;
using UnityEngine.UI;

namespace Backpack.View
{
    public class BackpackButton : MonoBehaviour
    {
        [SerializeField] private Button backpackButton;
        [SerializeField] private GameObject backpackPanel;

        private void Start()
        {
            backpackButton.onClick.AddListener(OnBackpackClose);
        }

        private void OnBackpackClose()
        {
            backpackPanel.SetActive(true);
        }
    }
}