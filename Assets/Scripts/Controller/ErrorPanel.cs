using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class ErrorPanel : MonoBehaviour
    {
        private static readonly int Close = Animator.StringToHash("Close");
        private static readonly int Open = Animator.StringToHash("Open");
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI errorText;
        [SerializeField] private Animator animator;

        private void Awake()
        {
            closeButton.onClick.AddListener(CloseFun);
        }

        public void WriteError(Exception error)
        {
            errorText.text = error.Message;
            animator.SetTrigger(Open);
        }

        private void CloseFun()
        {
            animator.SetTrigger(Close);
            StartCoroutine(Des());
        }

        private IEnumerator Des()
        {
            yield return 15;
            Destroy(gameObject);
        }
    }
}