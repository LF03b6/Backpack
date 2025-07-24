using System;
using System.Linq;
using Backpack.Controller;
using Backpack.Definitions;
using Manager;
using Model.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Backpack.Controller
{
    public class AddAnyController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField count;
        [SerializeField] private Button ok;
        private BackpackController _controller;
        private Item[] _items;

        private void Start()
        {
            var gaI = GameManager.instance;
            _controller = gaI.backpackController;
            _items = gaI.resourceItems;
            ok.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            try
            {
                var val = int.Parse(count.text);
                if (_items == null)
                {
                    Debug.Log("AddAnyController: No Items Found");
                    return;
                }

                for (var i = 0; i < val; i++)
                {
                    var idx = UnityEngine.Random.Range(0, _items.Length);
                    var item = _items[idx];
                    _controller.Add(
                        new global::Backpack.Model.Entities.Item(item.id, item.type, item.quality, item.icon, 1));
                }

                Debug.Log($"Has Added {val} items by random");
            }
            catch (Exception e)
            {
                GameManager.instance.ShowError(e);
            }
        }
    }
}