using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class Storage_database {
    public static Storage_database data
    {
        get
        {
            if(instance == null)
            {
                instance = new Storage_database();
                load_shops();
            }
            return instance;
        }
    }
    private static Storage_database instance;


    public  Storage[] shops;

    public static void load_shops()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Storage_database));
        FileStream filestream = new FileStream(Application.dataPath + "/shops.data", FileMode.Open);
        instance = xmlSerializer.Deserialize(filestream) as Storage_database;

        Debug.Log("loaded");
        Debug.Log(instance.shops[0].name);
    }
    public static void save_shops()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Storage_database));
        FileStream filestream = new FileStream(Application.dataPath + "/shops.data", FileMode.Create);
        xmlSerializer.Serialize(filestream, instance);
        filestream.Close();
    }

    public Storage GetStorage(string name)
    {
        foreach (Storage shop in shops)
        {
            if (shop.name == name)
            {
                return shop;
            }
        }
        return null;
    }
    
}
