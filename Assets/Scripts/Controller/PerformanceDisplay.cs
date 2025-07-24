using TMPro;
using UnityEngine;
using System;

namespace Controller
{
    public class PerformanceDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fpsText;
        [SerializeField] private TextMeshProUGUI memoryText;
        [SerializeField] private TextMeshProUGUI freamTimeText;
        private float _timer;

        private void Update()
        {
            _timer += Time.unscaledDeltaTime;
            if (!(_timer >= 0.5f)) return;
            _timer = 0f;
            var fps = 1f / Time.unscaledDeltaTime;
            fpsText.text = fps.ToString("F1");
            var memory = GC.GetTotalMemory(false) / 1024 / 1024;
            memoryText.text = memory.ToString("F1");
            var freamTime = Time.deltaTime * 1000f;
            freamTimeText.text = freamTime.ToString("F1");
        }
    }
}