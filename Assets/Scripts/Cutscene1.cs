using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour {

    GameObject player, doc, box1, box2, sprite;
    Text d1, d2;
    public bool stop, left, right,up,fullstop, exit;
    Vector3 down1, left1, right1, up1,flip;
    public int timer1, timer2;
   

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        doc = GameObject.FindGameObjectWithTag("enemy");
        down1 = player.transform.position;
        left1 = player.transform.position;
        right1 = player.transform.position;
        up1 = player.transform.position;
        stop = false;
        left = false;
        right = false;
        up = false;
        timer1 = 0;
        timer2 = 0;
        exit = false;

        box1 = GameObject.FindGameObjectWithTag("Dialog 1");
        box2 = GameObject.FindGameObjectWithTag("Dialog2");
        sprite = GameObject.FindGameObjectWithTag("Key");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer1 == 60)
        {
            fullstop = false;
            left = true;
            box1.gameObject.GetComponentInChildren<Text>().enabled = false;
            box1.gameObject.GetComponentInChildren<Image>().enabled = false;
        }

        if (timer1 > 60)
        {
            fullstop = true;
        }

        if(timer2 > 60)
        {
            fullstop = true;
        }

        if(timer2 == 60)
        {
            fullstop = false;
            right = true;
            box2.gameObject.GetComponentInChildren<Text>().enabled = false;
            box2.gameObject.GetComponentInChildren<Image>().enabled = false;
        }

        if(!stop)
        {
            down1.y -= 0.02f;
            player.transform.position = down1;
        }

        if(up)
        {
            up1.y += 0.02f;
            player.transform.position = up1;
        }

        if (player.transform.position.y <= -2.5 && exit == false)
        {
            stop = true;
            left = true;
        }
		
        if(player.transform.position.x >= 6.5 && exit == true)
        {
            right = false;
            up = true;
        }

        if(player.transform.position.y >= 0 && exit == true)
        {
            SceneManager.LoadScene(6);
        }

        if(left)
        {
            left1.x -= 0.03f;
            player.transform.position = left1;
        }

        if(right)
        {
            right1.x += 0.03f;
            player.transform.position = right1;
        }

        if(fullstop)
        {
            player.transform.position = player.transform.position;
            timer1--;
            timer2--;
        }
        down1 = player.transform.position;
        left1 = player.transform.position;
        right1 = player.transform.position;
        up1 = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("TxtBox") && exit == false)
        {
            left = false;
            timer1 = 460;

            box1.gameObject.GetComponentInChildren<Text>().enabled = true;
            box1.gameObject.GetComponentInChildren<Image>().enabled = true;

        }

        if (collision.gameObject.CompareTag("txt2"))
        {
            left = false;
            fullstop = true;
            timer1 = 0;
            timer2 = 800;
            exit = true;

            flip = player.transform.localScale;
            flip.x = flip.x * -1;
            player.transform.localScale = flip;

            sprite.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            box2.gameObject.GetComponentInChildren<Text>().enabled = true;
            box2.gameObject.GetComponentInChildren<Image>().enabled = true;

        }
    }

}
