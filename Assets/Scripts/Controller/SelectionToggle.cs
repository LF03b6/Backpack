using Lib;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public sealed class SelectionToggle : MonoBehaviour
    {
        [SerializeField] private Toggle thisToggle;
        [SerializeField] private ESelectionType thisType;

        public Toggle toggle => thisToggle;
        public ESelectionType type => thisType;
    }
}