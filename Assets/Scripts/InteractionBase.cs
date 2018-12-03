using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    public GameObject obj = null;
    public GameObject inv;


    void Start()
    {
            
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Interact"))
        {
            obj = collision.gameObject;
            obj.SendMessage("Interact");

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Interact"))
        {
            if(other.gameObject == obj)
            {
                obj = null;
            }
            
        }
    }
}