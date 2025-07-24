using System.Collections;
using Manager;
using UnityEngine;

namespace Backpack.View
{
    public class BackpackUI : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(Fresh());
        }

        private static IEnumerator Fresh()
        {
            // 只能延迟了，因为初次调用链是SetActive开始的
            // 本帧是不执行Start的
            // 但是三方库初始化又依靠Start
            yield return null;
            GameManager.instance.backpackController.ReSizeUI();
        }
    }
}