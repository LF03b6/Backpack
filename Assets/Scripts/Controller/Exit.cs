using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class Exit : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnExit);
        }

        private static void OnExit()
        {
            Application.Quit();
        }
    }
}