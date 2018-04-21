using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class Shop_database {
    public static Shop_database data
    {
        get
        {
            if(instance == null)
            {
                instance = new Shop_database();
                load_shops();
            }
            return instance;
        }
    }
    private static Shop_database instance;


    public  Shop[] shops;

    public static void load_shops()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shop_database));
        FileStream filestream = new FileStream(Application.dataPath + "/shops.data", FileMode.Open);
        instance = xmlSerializer.Deserialize(filestream) as Shop_database;

        Debug.Log("loaded");
        Debug.Log(instance.shops[0].name);
    }
    public static void save_shops()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shop_database));
        FileStream filestream = new FileStream(Application.dataPath + "/shops.data", FileMode.Create);
        xmlSerializer.Serialize(filestream, instance);
        filestream.Close();
    }

    public Shop GetShop(string name)
    {
        foreach (Shop shop in shops)
        {
            if (shop.name == name)
            {
                return shop;
            }
        }
        return null;
    }
    
}
