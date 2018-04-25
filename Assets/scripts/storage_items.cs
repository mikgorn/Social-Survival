using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class storage_items : MonoBehaviour {
    Storage storage;
    public Item[] items;
    // Use this for initialization
    void Start () {
        Storage_database storage_database = Storage_database.data;

        storage = storage_database.GetStorage(gameObject.name);
        items = storage.items;
        


	}
    public void remove_item(Item item)
    {
        foreach(Item item_ex in items)
        {
            if (item_ex.name == item.name)
            {
                Item new_item = new Item();
                new_item.name = item.name;
                new_item.price = item.price;
                new_item.nutrition = item.nutrition;
                new_item.warm = item.warm;
                new_item.happiness = item.happiness;
                new_item.amount = item_ex.amount - item.amount;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
