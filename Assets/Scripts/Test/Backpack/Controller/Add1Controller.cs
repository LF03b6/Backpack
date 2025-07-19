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
    public class Add1Controller : MonoBehaviour
    {
        [SerializeField] private TMP_InputField id;
        [SerializeField] private TMP_InputField type;
        [SerializeField] private TMP_InputField amount;
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
                var idv = uint.Parse(id.text);
                var dataType = (DataType)int.Parse(type.text);
                var increment = int.Parse(amount.text);
                var i = _items.First(item => item.id == idv && item.type == dataType);
                var newItem = new global::Backpack.Model.Entities.Item(i);
                newItem.ReAmount(increment);
                _controller.Add(newItem);

                Debug.Log("Added " + newItem.id + " to " + newItem.type);
            }
            catch (Exception e)
            {
                Debug.Log("Error" + e.Message);
            }
        }
    }
}