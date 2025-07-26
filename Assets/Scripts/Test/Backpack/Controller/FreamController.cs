using System;
using Controller;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Test.Backpack.Controller
{
    public class FreamController : MonoBehaviour
    {
        [SerializeField] private Button ensure;
        [SerializeField] private TMP_InputField text;

        private void Awake()
        {
            ensure.onClick.AddListener(Apply);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void Apply()
        {
            try
            {
                var num = int.Parse(text.text);
                Application.targetFrameRate = num;
            }
            catch (Exception e)
            {
                GameManager.instance.ShowError(e);
            }
        }
    }
}