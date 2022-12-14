using DungeonCrawl.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core
{
    /// <summary>
    ///     Class for handling text on user interface (UI)
    /// </summary>
    public class UserInterface : MonoBehaviour
    {
        public enum TextPosition : byte
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        /// <summary>
        ///     User Interface singleton
        /// </summary>
        public static UserInterface Singleton { get; private set; }

        private TextMeshProUGUI[] _textComponents;
        private Sprite _inventorySlotSprite;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }
            
            Singleton = this;

            _textComponents = GetComponentsInChildren<TextMeshProUGUI>();
            _inventorySlotSprite = Resources.Load<Sprite>("inventoryitem");
        }

        /// <summary>
        ///     Changes text at given screen position
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textPosition"></param>
        public void SetText(string text, TextPosition textPosition, float size = 55.0f)
        {
            _textComponents[(int) textPosition].text = text;
            _textComponents[(int) textPosition].fontSize = size;
        }
        public void SetText(string text, TextPosition textPosition, Color color)
        {
            _textComponents[(int)textPosition].text = text;
            _textComponents[(int)textPosition].color = color;
        }

        public void SetInventorySlot(int position, int spirteId, int number = 0)
        {
            var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
            var slot = inventory.transform.GetChild(position);
            //var slot = transform.Find("Inventory").GetChild(position);
            slot.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(spirteId);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = number == 1 ? string.Empty : number.ToString();

        }

        public void SetInventorySlot(int position)
        {
            var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
            var slot = inventory.transform.GetChild(position);
            //var slot = transform.Find("Inventory").GetChild(position);
            slot.GetComponent<Image>().sprite = _inventorySlotSprite;
        }

        public void SetInventorySlotSelected(int position, float x,float y)
        {
            var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
            var slot = inventory.transform.GetChild(position);
            //var slot = transform.Find("Inventory").GetChild(position);
            slot.GetComponent<Image>().transform.localScale = new Vector3(x,y,1.0f);
            
        }


    }
}
