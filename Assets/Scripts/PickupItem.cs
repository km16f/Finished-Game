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
        test = GameObject.FindWithTag("Weapon");
        selected = test.gameObject.GetComponent<PickupItem>().selected;
        
      
        if (collected == true && selected == true)
        {
            if(player.GetComponent<PlayerController>().isHiding == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            gameObject.transform.position = player.gameObject.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            if (player.transform.localScale.x > 0)
            {
                Vector3 temp = gameObject.transform.position;
                temp.x = player.transform.position.x + 0.277f;
                temp.y = player.transform.position.y - 0.068f;
                gameObject.transform.position = temp;

                if (gameObject.transform.localScale.x > 0)
                {
                    Vector2 temp2 = gameObject.transform.localScale;
                    temp2.x *= -1;
                    gameObject.transform.localScale = temp2;
                }
            }
            else if (player.transform.localScale.x < 0)
            {
                Vector3 temp = gameObject.transform.position;
                temp.x = player.transform.position.x - 0.343f;
                temp.y = player.transform.position.y - 0.068f;
                gameObject.transform.position = temp;

                if (gameObject.transform.localScale.x < 0)
                {
                    Vector2 temp2 = gameObject.transform.localScale;
                    temp2.x *= -1;
                    gameObject.transform.localScale = temp2;
                }

            }


           
        }
        else if(collected == true && selected == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
