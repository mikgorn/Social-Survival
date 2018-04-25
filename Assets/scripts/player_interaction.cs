using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_interaction : MonoBehaviour {

    player_inventory inventory_script;

    public GameObject panel;
    public List<GameObject> UI_items;
    public GameObject button_prefab;
    public GameObject text_prefab;
    public Text text;
	// Use this for initialization
	void Start () {
        panel.SetActive(false);

        inventory_script = gameObject.GetComponent<player_inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "seller")
        {
            panel.SetActive(true);
            text.text = collision.gameObject.name;
            storage_items seller = (storage_items)collision.gameObject.GetComponent<storage_items>();
            Item[] shop_items = seller.items;

            int shift_y = +120;

            foreach (Item item in shop_items)
            {
                GameObject button = (GameObject)Instantiate(button_prefab);
                button.transform.SetParent(panel.transform, false);
                button.transform.localScale = new Vector3(1, 1, 1);

                Button btn = button.GetComponent<Button>();
                btn.onClick.AddListener(()=> inventory_script.buy_item(item));
                
                Text txt = button.GetComponentInChildren<Text>();
                txt.text = "Buy";

                button.transform.position += new Vector3(50,shift_y,0);
                

                GameObject text = (GameObject)Instantiate(text_prefab);
                text.transform.SetParent(panel.transform, false);
                text.transform.localScale = new Vector3(1, 1, 1);

                txt = text.GetComponent<Text>();
                txt.text = item.name + " " + item.price;

                text.transform.position += new Vector3(-30, shift_y, 0);
                shift_y -= 30;

                UI_items.Add(button);
                UI_items.Add(text);
            }
        }
        if (collision.gameObject.tag == "storage")
        {
            panel.SetActive(true);
            text.text = collision.gameObject.name;
            storage_items seller = (storage_items)collision.gameObject.GetComponent<storage_items>();
            Item[] shop_items = seller.items;

            int shift_y = +120;

            foreach (Item item in shop_items)
            {
                GameObject button = (GameObject)Instantiate(button_prefab);
                button.transform.SetParent(panel.transform, false);
                button.transform.localScale = new Vector3(1, 1, 1);

                Button btn = button.GetComponent<Button>();
                btn.onClick.AddListener(() => inventory_script.buy_item(item));

                Text txt = button.GetComponentInChildren<Text>();
                txt.text = "Buy";

                button.transform.position += new Vector3(50, shift_y, 0);


                GameObject text = (GameObject)Instantiate(text_prefab);
                text.transform.SetParent(panel.transform, false);
                text.transform.localScale = new Vector3(1, 1, 1);

                txt = text.GetComponent<Text>();
                txt.text = item.name + " " + item.price;

                text.transform.position += new Vector3(-30, shift_y, 0);
                shift_y -= 30;

                UI_items.Add(button);
                UI_items.Add(text);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "seller")|(collision.gameObject.tag == "storage"))
        {
            panel.SetActive(false);
            foreach (GameObject obj in UI_items)
            {
                Destroy(obj);
                
            }
            UI_items.Clear();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
