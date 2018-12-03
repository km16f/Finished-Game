using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour {

    public GameObject player;
    public float xstart;
    public float xend;
    public float ystart;
    public float yend;

	
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	
	void Update ()
    {
        float x = Mathf.Clamp(player.transform.position.x, xstart, xend);
        float y = Mathf.Clamp(player.transform.position.y, ystart, yend);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
