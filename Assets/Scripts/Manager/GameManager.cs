using System;
using Backpack.Model.Entities;
using Core.EventBus;
using UnityEngine;

namespace Manager
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        public Backpack.Controller.BackpackController backpackController { get; private set; }
        public EventDispatcher eventDispatcher { get; private set; }
        private const string Path = "Items";
        public Model.Entities.Item[] resourceItems { get; private set; }

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

        private void Start()
        {
            resourceItems = Resources.LoadAll<Model.Entities.Item>(Path);
        }

        private void RegisterManager()
        {
            backpackController = new Backpack.Controller.BackpackController();
            eventDispatcher = new EventDispatcher();
        }
    }
}