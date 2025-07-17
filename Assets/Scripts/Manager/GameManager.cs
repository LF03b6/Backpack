using System;
using Model;
using UnityEngine;

namespace Manager
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        public BackpackManager backpackManager { get; private set; }

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            RegisterManager();
        }

        private void RegisterManager()
        {
            backpackManager = new BackpackManager();
        }
    }
}