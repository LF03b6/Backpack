using Lib;
using Manager;
using UnityEngine;

namespace Controller
{
    public class TogglesSelection : MonoBehaviour
    {
        [SerializeField] private SelectionToggle[] toggles;

        private void Start()
        {
            if (toggles.Length > 0) return;
            Debug.LogWarning($"{nameof(TogglesSelection)}.{nameof(Start)} is null, try get by Find.");
            var items = transform.GetComponentsInChildren<SelectionToggle>(true);
            toggles = items;

            foreach (var toggle in toggles)
            {
                var thisType = toggle.type;
                var thisToggle = toggle.toggle;
                thisToggle.onValueChanged.AddListener(isOn => SetType(isOn, thisType));

                if (thisToggle.isOn)
                    SetType(true, thisType);
            }
        }

        private static void SetType(bool isOn, ESelectionType type)
        {
            if (isOn)
                GameManager.instance.backpackManager.ResetSelectionType(type);
        }
    }
}