using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public GameObject player,test,inv,copy;
    public bool collected = false;
    public bool selected = false;
    float xs, ys;
   
	

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inv = GameObject.FindGameObjectWithTag("Inventory");
        
	}

    void Update()
    {
        
        //test = GameObject.FindWithTag("Weapon");
        //selected = test.gameObject.GetComponent<PickupItem>().selected;
       
      
        if (collected == true && selected == true)
        {
            if (player.GetComponent<PlayerController>().isHiding == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
           
        }
        
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("Player"))
         {
            gameObject.transform.position = other.transform.position;
            collected = true;
            selected = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            copy = gameObject;
            inv.gameObject.GetComponent<InventoryUI>().AddItem(copy);
        }
    }
    
    void OnMouseDown()
    {
        selected = !selected;
    }

}
