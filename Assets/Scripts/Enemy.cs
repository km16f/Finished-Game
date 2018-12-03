using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D baddie;
   public bool touching;
    public int timeatt,time;
    public GameObject player,temp;
    public int healthed, damage;
    bool hehide;
    bool ispress = false;

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        timeatt = 15;
        time = 0;
        touching = false;
        baddie = gameObject.GetComponent<Rigidbody2D>();
        baddie.velocity = new Vector2(-1f,0);
	}
	
	
	void Update ()
    {
        hehide = player.GetComponent<Health>().thishide;
        ispress = false;

        if(Input.GetKeyDown("r") && player.GetComponent<Health>().isAlive == false)
        {
            gameObject.transform.position = new Vector3(16.76f, 2.99f, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            temp = GameObject.FindWithTag("WinTxt");
            temp.gameObject.GetComponent<Canvas>().enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && hehide == false)
        {
            Debug.Log("in trigger");
            touching = true;
            hehide = other.gameObject.GetComponent<Health>().thishide;
            healthed = other.gameObject.GetComponent<Health>().fhealth;
            doDamage();  
        }
    }

   /* private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            touching = false;

        }
    }*/

    void doDamage()
    {
        player.gameObject.GetComponent<Health>().fhealth = healthed - damage;
        time = 0;
    }
}

