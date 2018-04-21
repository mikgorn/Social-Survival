using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_inventory : MonoBehaviour {

    public Text money_status;
    public int money = 1000;
    public static List<Item> inventory;
    public List<GameObject> UI_items;
    public GameObject button_prefab;
    public GameObject item_prefab;
    public GameObject panel;

    public bool show_inventory = false;


    public void add_item(Item item )
    {
        refresh_inventory();
        Item new_item = new Item();
        new_item.name = item.name;
        new_item.price = item.price;
        new_item.nutrition = item.nutrition;
        new_item.warm = item.warm;
        new_item.happiness = item.happiness;
        int i = inventory.FindIndex(a => a.name == item.name);
        if (i != -1)
        {
            
            new_item.amount = inventory[i].amount + item.amount;
            inventory.RemoveAt(i);
            
        }
        else
        {
            new_item.amount =  item.amount;
        }
        inventory.Add(new_item);
    }
    public void buy_item(Item item)
    {
        
        if (money >= item.price)
        {
            money -= item.price;
            item.amount = 10;
            add_item(item);
        }
        refresh_inventory();
    }
	// Use this for initialization
	void Start () {
        inventory = new List<Item>();
        UI_items = new List<GameObject>();
        
	}
	
	// Update is called once per frame
	void Update () {
        refresh_money();

        if (show_inventory)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }

        if (Input.GetKeyDown("i"))
        {
            show_inventory = !show_inventory;

            refresh_inventory();
        }
	}

    public void refresh_money()
    {
        money_status.text = "Money: " + money;
    }
    public void refresh_inventory()
    {
        foreach (GameObject obj in UI_items)
        {
            Destroy(obj);

        }
        UI_items.Clear();
        int shift_y = 50;
        
        foreach (Item item in inventory)
        {
            GameObject item_gameobj = (GameObject)Instantiate(item_prefab);
            item_gameobj.transform.SetParent(panel.transform, false);
            item_gameobj.transform.localScale = new Vector3(1, 1, 1);

            Text[] text = item_gameobj.GetComponentsInChildren<Text>();
            text[0].text = item.name;
            text[1].text = ""+item.nutrition;
            text[2].text = ""+item.warm;
            text[3].text = ""+item.happiness;
            text[4].text = ""+item.amount;

            Button[] button = item_gameobj.GetComponentsInChildren<Button>();
            button[0].onClick.AddListener(() => read_info(item));
            button[1].onClick.AddListener(() => use_item(item));

            item_gameobj.transform.position += new Vector3(160, shift_y, 0);
            shift_y -= 30;

            UI_items.Add(item_gameobj);
        }
        
    }
    public void read_info(Item item)
    {

    }
    public void use_item(Item item)
    {
        int i = inventory.FindIndex(a => a.name == item.name);
        inventory[i].amount -= 1;
        if (inventory[i].amount == 0)
        {
            inventory.RemoveAt(i);
        }
        refresh_inventory();
    }
}
