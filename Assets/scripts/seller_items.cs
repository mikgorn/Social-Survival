using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class seller_items : MonoBehaviour {
    Shop shop;
    public Item[] items;
    // Use this for initialization
    void Start () {
        Shop_database shop_database =Shop_database.data;
        
        shop = shop_database.GetShop(gameObject.name);
        items = shop.items;

        Debug.Log(items[0].name);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
