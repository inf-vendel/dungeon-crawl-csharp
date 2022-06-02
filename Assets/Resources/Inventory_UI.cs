using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject Inventory;
    private static Sprite _inventorySlotSprite;

    void Start()
    {
        Inventory.SetActive(false);
        _inventorySlotSprite = Resources.Load<Sprite>("inventoryitem");
    }
    
    void Update()
    {
        var player = ActorManager.Singleton.GetPlayer();
        Inventory.SetActive(player.PlayerInventory._isOpen);
    }

    public static void SetInventorySlot(int position, int spirteId, int number = 0)
    {
        var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
        var slot = inventory.transform.GetChild(position);
        //var slot = transform.Find("Inventory").GetChild(position);
        slot.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(spirteId);
        slot.GetComponentInChildren<TextMeshProUGUI>().text = number == 1 ? string.Empty : number.ToString();

    }

    public static void SetInventorySlot(int position)
    {
        var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
        var slot = inventory.transform.GetChild(position);
        //var slot = transform.Find("Inventory").GetChild(position);
        slot.GetComponent<Image>().sprite = _inventorySlotSprite;
    }

    public static void SetInventorySlotSelected(int position, float x, float y)
    {
        var inventory = GameObject.FindGameObjectWithTag("INVENTORY");
        var slot = inventory.transform.GetChild(position);
        //var slot = transform.Find("Inventory").GetChild(position);
        slot.GetComponent<Image>().transform.localScale = new Vector3(x, y, 1.0f);

    }

}