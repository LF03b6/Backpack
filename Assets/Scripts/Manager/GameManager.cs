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

            Init();
        }

        private void Init()
        {
            resourceItems = Resources.LoadAll<Model.Entities.Item>("Items");
            backpackController = new Backpack.Controller.BackpackController();
            eventDispatcher = new EventDispatcher();
        }
    }
}