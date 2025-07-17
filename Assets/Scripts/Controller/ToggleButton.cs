using Lib;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public sealed class ToggleButton : MonoBehaviour
    {
        [SerializeField] private Toggle thisToggle;
        [SerializeField] private EDataType thisType;

        public Toggle toggle => thisToggle;
        public EDataType type => thisType;
    }
}