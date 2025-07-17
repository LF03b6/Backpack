using Lib;
using Manager;
using UnityEngine;

namespace Controller
{
    public class TogglesGroupSelection : MonoBehaviour
    {
        [SerializeField] private ToggleButton[] toggles;

        private void Start()
        {
            if (toggles.Length <= 0)
            {
                Debug.LogWarning($"{nameof(TogglesGroupSelection)}.{nameof(Start)} is null, try get by Find.");
                var items = transform.GetComponentsInChildren<ToggleButton>(true);
                toggles = items;
            }

            foreach (var toggle in toggles)
            {
                var thisType = toggle.type;
                var thisToggle = toggle.toggle;
                thisToggle.onValueChanged.AddListener(isOn => SetType(isOn, thisType));

                // 初始触发逻辑
                if (thisToggle.isOn)
                    SetType(true, thisType);
            }
        }

        private static void SetType(bool isOn, EDataType type)
        {
            if (isOn)
                GameManager.instance.backpack.SwitchDataSource(type);
        }
    }
}