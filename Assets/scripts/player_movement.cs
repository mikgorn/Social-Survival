using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {

    private Rigidbody2D player;
    public int speed = 100;

	// Use this for initialization
	void Start () {
        player = this.gameObject.GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        float speedx = Input.GetAxis("Vertical");
        float speedy = Input.GetAxis("Horizontal");
        player.AddForce(transform.up*speedx*speed);
        player.AddForce(transform.right * speedy * speed);
        
    }
   
}
