using System;
using Backpack.Model.Entities;
using Backpack.Provider;
using Controller;
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
        [SerializeField] private GameObject errorPanel;
        [SerializeField] private GameObject canvas;
        [SerializeField] private SlotsPoolProvider provider;

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
            backpackController = new Backpack.Controller.BackpackController(provider);
            eventDispatcher = new EventDispatcher();
        }

        public void ShowError(Exception e)
        {
            var obj = Instantiate(errorPanel, canvas.transform);
            var controller = obj.GetComponent<ErrorPanel>();
            controller.WriteError(e);
        }
    }
}