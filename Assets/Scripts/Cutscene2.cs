using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour {
    bool done;

    public TextAsset textMom, textDad;
    public string[] momLines, dadLines;

    public Text box;
    public Text temp = null;
    public GameObject t1, t2, t3, t4, t5, m1, m2, m3, m4, m5;

   
    int click;

    void Start () {
        t1 = GameObject.FindGameObjectWithTag("RoomChange1");
        t2 = GameObject.FindGameObjectWithTag("RoomChange2");
        t3 = GameObject.FindGameObjectWithTag("Roomchange3");
        t4 = GameObject.FindGameObjectWithTag("RoomChange4");
        t5 = GameObject.FindGameObjectWithTag("RoomChange5");

        m1 = GameObject.FindGameObjectWithTag("Dialog 1");
        m2 = GameObject.FindGameObjectWithTag("Dialog2");
        m3 = GameObject.FindGameObjectWithTag("Dialog3");
        m4 = GameObject.FindGameObjectWithTag("Dialog4");
        m5 = GameObject.FindGameObjectWithTag("Dialog5");

        click = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetMouseButtonDown(0))
        {
            click++;
        }

        if(click == 1)
        {
            m1.gameObject.GetComponentInChildren<Text>().enabled = true;
            m1.gameObject.GetComponentInChildren<Image>().enabled = true;
        }

        if(click == 3)
        {
            m1.gameObject.GetComponentInChildren<Text>().enabled = false;
            m1.gameObject.GetComponentInChildren<Image>().enabled = false;

            m2.gameObject.GetComponentInChildren<Text>().enabled = true;
            m2.gameObject.GetComponentInChildren<Image>().enabled = true;
        }

        if (click == 5)
        {
            m2.gameObject.GetComponentInChildren<Text>().enabled = false;
            m2.gameObject.GetComponentInChildren<Image>().enabled = false;

            m3.gameObject.GetComponentInChildren<Text>().enabled = true;
            m3.gameObject.GetComponentInChildren<Image>().enabled = true;
        }

        if (click == 7)
        {
            m3.gameObject.GetComponentInChildren<Text>().enabled = false;
            m3.gameObject.GetComponentInChildren<Image>().enabled = false;

            m4.gameObject.GetComponentInChildren<Text>().enabled = true;
            m4.gameObject.GetComponentInChildren<Image>().enabled = true;
        }

        if (click == 9)
        {
            m4.gameObject.GetComponentInChildren<Text>().enabled = false;
            m4.gameObject.GetComponentInChildren<Image>().enabled = false;

            m5.gameObject.GetComponentInChildren<Text>().enabled = true;
            m5.gameObject.GetComponentInChildren<Image>().enabled = true;
        }

        if(click == 2)
        {
            t1.gameObject.GetComponentInChildren<Text>().enabled = true;
            t1.gameObject.GetComponentInChildren<Text>().enabled = true;
        }

        if (click == 4)
        {
            t1.gameObject.GetComponentInChildren<Text>().enabled = false;
            t1.gameObject.GetComponentInChildren<Text>().enabled = false;

            t2.gameObject.GetComponentInChildren<Text>().enabled = true;
            t2.gameObject.GetComponentInChildren<Text>().enabled = true;
        }


        if (click == 6)
        {
            t2.gameObject.GetComponentInChildren<Text>().enabled = false;
            t2.gameObject.GetComponentInChildren<Text>().enabled = false;

            t3.gameObject.GetComponentInChildren<Text>().enabled = true;
            t3.gameObject.GetComponentInChildren<Text>().enabled = true;
        }


        if (click == 8)
        {
            t3.gameObject.GetComponentInChildren<Text>().enabled = false;
            t3.gameObject.GetComponentInChildren<Text>().enabled = false;

            t4.gameObject.GetComponentInChildren<Text>().enabled = true;
            t4.gameObject.GetComponentInChildren<Text>().enabled = true;
        }

        if(click == 10)
        {
         t4.gameObject.GetComponentInChildren<Text>().enabled = false;
         t4.gameObject.GetComponentInChildren<Text>().enabled = false;

         t5.gameObject.GetComponentInChildren<Text>().enabled = true;
         t5.gameObject.GetComponentInChildren<Text>().enabled = true;
        }

        if(click > 13)
        {
            SceneManager.LoadScene(9);
        }

    }

   

}
