using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
   
    public int fhealth;
    float damaged;
    //public GameObject player;
    public GameObject[] list;
    public GameObject bloodParticles;
   public bool inZone, isAlive;
    public SpriteRenderer temp;
    public bool thishide = false;
    Vector3 pos;
    

	void Start ()
    {

        thishide = gameObject.GetComponent<PlayerController>().isHiding;
        fhealth = 100;
            isAlive = true;
        pos = gameObject.transform.position;
	}
	
	
	void Update ()
    {
        if (isAlive)
        {
            thishide = gameObject.GetComponent<PlayerController>().isHiding;
            if (fhealth <= 0)
            {
                Debug.Log("wrong one");
                isAlive = false;
                gameObject.transform.Rotate(0, 0, 90);
                gameObject.GetComponent<PlayerController>().speed = 0;
                float t1, t2;
                t1 = gameObject.transform.position.x;
                t2 = gameObject.transform.position.y - 0.9f;
                gameObject.transform.position = new Vector3(t1, t2, gameObject.transform.position.z);
                Instantiate(bloodParticles, gameObject.transform.position, gameObject.transform.rotation);
                //gameObject.GetComponent<PlayerController>().s = PlayerController.State.Dead;
                //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
        }

        if (!isAlive)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            
            
            if(Input.GetKeyDown("r"))
            {
                Respawn();
            }
        }
    }



    void Respawn()
    {
        fhealth = 100;
        isAlive = true;
        gameObject.transform.Rotate(0, 0, -90);
        gameObject.transform.position = pos;
        gameObject.GetComponent<PlayerController>().speed = 10;
       // gameObject.GetComponent<PlayerController>().s = PlayerController.State.Standing;
    }
}
