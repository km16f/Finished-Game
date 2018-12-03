using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{

    public GameObject temp;


    void Start() {
        temp = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        if(temp.gameObject.GetComponent<Health>().fhealth <= 0.0f)
        {
            gameObject.GetComponent<Canvas>().enabled = true; ;
        }
        else
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}