using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

   
    public float fhealth;
    float damaged;
    public GameObject player;
    public GameObject[] list;
   public bool inZone, isAlive;
    public SpriteRenderer temp;
    public bool thishide = false;
    

	void Start ()
    {

        thishide = gameObject.GetComponent<PlayerController>().isHiding;
        fhealth = 100;
        isAlive = true;
	}
	
	
	void Update ()
    {
        if (isAlive)
        {
            thishide = gameObject.GetComponent<PlayerController>().isHiding;
            if (fhealth <= 0)
            {
                isAlive = false;
                gameObject.transform.Rotate(0, 0, 90);
                gameObject.GetComponent<PlayerController>().speed = 0;
                float t1, t2;
                t1 = gameObject.transform.position.x;
                t2 = gameObject.transform.position.y - 0.5f;
                gameObject.transform.position = new Vector3(t1, t2, gameObject.transform.position.z);
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
        }
        else if(!isAlive)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            
            if(Input.GetKeyDown("r"))
            {
                respawn();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void respawn()
    {
        fhealth = 100;
        isAlive = true;
        gameObject.transform.Rotate(0, 0, -90);
        gameObject.transform.position = new Vector3(1.73f, 1.74f, 0);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
