using Controller;
using UnityEngine;
using Utils;

namespace Manager
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        public Backpack backpack { get; private set; }
        public EventDispatcher eventDispatcher { get; private set; }

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
            backpack = new Backpack();
            eventDispatcher = new EventDispatcher();
        }
    }
}