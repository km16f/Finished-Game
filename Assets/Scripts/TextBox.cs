using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {
   public bool done = false;

    public TextAsset textfile;
    public string[] textlines;

    public Text box;
    public Text temp = null;
    public GameObject canvas = null,test;

    public int time;
    public int currentLine;
    public int endAtLine;


    private void OnTriggerEnter2D(Collider2D collision)
    {

       if(collision.gameObject.CompareTag("Player"))
        {
            currentLine = 0;
            temp = canvas.gameObject.GetComponentInChildren(typeof(Text)) as Text;
            temp.GetComponent<Text>().text = textlines[currentLine];
            Debug.Log("Problem is her");
            if (done != true)
            {
                canvas.gameObject.GetComponentInChildren<Image>().enabled = true;
                canvas.gameObject.GetComponentInChildren<Text>().enabled = true;
            }
        }
    }

    void Start () {
        canvas = GameObject.FindGameObjectWithTag("TxtBox");
        canvas.gameObject.GetComponentInChildren<Image>().enabled = false;
        canvas.gameObject.GetComponentInChildren<Text>().enabled = false;
        currentLine = 0;
        time = 350;

        if(textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }
	}

    /*private void OnMouseDown()
    {
        if (currentLine != endAtLine)
        {
            currentLine++;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            done = true;
        }
        
    }*/

    void Update () {
        if(currentLine != endAtLine)
        {
            temp.GetComponent<Text>().text = textlines[currentLine];
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (currentLine != endAtLine)
            {
                currentLine++;
            }
            else
            {
                canvas.gameObject.GetComponentInChildren<Image>().enabled = false;
                canvas.gameObject.GetComponentInChildren<Text>().enabled = false;
                done = true;
            }
        }

        /*if(canvas.gameObject.activeSelf == true)
        {
            time--;
        }
		
        if(time == 0)
        {
            canvas.gameObject.SetActive(false);
        }*/
	}
}
