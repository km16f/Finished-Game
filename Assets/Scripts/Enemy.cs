using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player,temp;
    public float healthed, damage;
    bool hehide;
    bool ispress = false;

	void Start ()
    {
       
        damage = 1000;
        player = GameObject.FindWithTag("Player");
	}
	
	
	void Update ()
    {
        hehide = player.GetComponent<Health>().thishide;
        ispress = false;

		if(ispress)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
        }
        else if (!ispress) { gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); }

        if(Input.GetKeyDown("r"))
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
            hehide = other.gameObject.GetComponent<Health>().thishide;
            healthed = other.gameObject.GetComponent<Health>().fhealth;
            other.gameObject.GetComponent<Health>().fhealth = healthed - damage;
        }
    }


}

