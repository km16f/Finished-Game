using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D baddie;
   public bool touching,mealive;
    public int timeatt, time, pushtime;
    public GameObject player,temp;
    public int healthed, damage, myhealth;
    bool hehide,dead,attack;
    bool ispress = false;
    Vector2 bump;
    Vector3 place;
    float check;
    public float rip;

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        timeatt = 15;
        time = 0;
        touching = false;
        baddie = gameObject.GetComponent<Rigidbody2D>();
        baddie.velocity = new Vector2(-1f,0);
        place = gameObject.transform.position;
        mealive = true;
        bump = new Vector2(2000f, 0f);
        pushtime = 30;
        myhealth = 100;
	}
	
	
	void Update ()
    {
        if(myhealth <= 0)
        {
            mealive = false;
        }

        if(mealive == true)
        {
            if (Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) < 10)
            {
                baddie.velocity = new Vector3(-3f, 0, 0);
            }
        }
        else
        {
            baddie.velocity = Vector3.zero;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8666f,0.0274f,0.0707f);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        hehide = player.GetComponent<Health>().thishide;
        ispress = false;

        if(!mealive)
        {
            Destroy(gameObject, 4);
        }

        if (player.gameObject.GetComponent<Health>().isAlive == false)
        {
            dead = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
       
        if(Input.GetKeyDown("r") && dead == true)
        {
            gameObject.transform.position = place;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            temp = GameObject.FindWithTag("WinTxt");
            temp.gameObject.GetComponent<Canvas>().enabled = false;
            mealive = true;
            myhealth = 100;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        pushtime = 30;
       // ispush = true;
        if (other.gameObject.tag == "Player" && hehide == false)
        {

            Debug.Log("in trigger");
            touching = true;
            hehide = other.gameObject.GetComponent<Health>().thishide;
            healthed = other.gameObject.GetComponent<Health>().fhealth;
            doDamage();
            pushBack();
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
        if(player.gameObject.GetComponent<PlayerController>().s != PlayerController.State.Attacking)
        {
            player.gameObject.GetComponent<Health>().fhealth = healthed - damage;
        }
        else
        {
            myhealth = myhealth - damage;
        }
        time = 0;
    }

    void pushBack()
    {
        pushtime--;
        baddie = gameObject.GetComponent<Rigidbody2D>();
        baddie.velocity = new Vector3(0f, 0f, 0f);
        baddie.AddForce(bump);
        
    }
}

