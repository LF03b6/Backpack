using Backpack.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Backpack.View
{
    public sealed class ToggleButton : MonoBehaviour
    {
        [SerializeField] private Toggle thisToggle;
        [SerializeField] private DataType thisType;

        public Toggle toggle => thisToggle;
        public DataType type => thisType;
    }
}