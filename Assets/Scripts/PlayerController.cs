 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
   public string scene;
    
    public float speed, sideMovement = 0.0f;
    private Rigidbody2D control;
    public float jumpforce;
    bool ground;
    bool faceRight;
    Vector3 spot,hidesafe;
   // public Animator animate;
    public bool isHiding;
    int collisionnum = 0;
    public GameObject player, temp,hide, txt,safe,canvasLoad;
    bool inZone = false;
    public Image item;
    public int time;
   public Sprite back, normal;

    public bool armed;
    public bool keyed;
 
    //public int s;

  public enum State { Standing, Walking, Jumping, Hiding, Attacking, Text, Dead };
   public State s;
    //public Text wins;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        speed = 10;
        s = 0;
        hide = GameObject.FindGameObjectWithTag("Hiding");
        safe = GameObject.FindGameObjectWithTag("safe");
        canvasLoad = GameObject.FindGameObjectWithTag("Canvas");
        faceRight = true;

    }
    

    void Update()
    {
       
        StateManager();
       /* temp = GameObject.FindWithTag("WinTxt");
        if (temp.gameObject.GetComponent<Canvas>().enabled == true && Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(0);
            collisionnum = 0;
        }*/

        if(Input.GetKeyDown("j"))
        {
            SceneManager.LoadScene(6);
        }

        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(8);
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            ground = false;
            control.AddForce(new Vector2(control.velocity.x, jumpforce));
        }
        s = State.Jumping;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hiding") && collisionnum % 2 == 1)
        {
            inZone = false;
            ++collisionnum;

        }
        else if (other.gameObject.CompareTag("Hiding") && collisionnum % 2 == 0)
        {
            inZone = true;
            ++collisionnum;
        }

        if (other.gameObject.CompareTag("FaceAway") && other.GetComponent<TextBox>().done == false)
        {
            txt = other.gameObject;
            //gameObject.GetComponent<SpriteRenderer>().sprite = back;
            
            s = State.Text;
        }

        if (other.gameObject.CompareTag("NoMoveTxt") && other.GetComponent<TextBox>().done == false)
        {
            txt = other.gameObject;
            s = State.Text;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            ground = true;
            
        }

        if(other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(2);

        }

        if (other.gameObject.CompareTag("RoomChange1"))
        {
            scene = "scene2";
            SceneManager.LoadScene(3);

        }

        if (other.gameObject.CompareTag("RoomChange2"))
        {
            scene = "scene3";
            SceneManager.LoadScene(4);
            
        }

        if (other.gameObject.CompareTag("Roomchange3"))
        {
            scene = "scene 4";
            SceneManager.LoadScene(5);
        }

        if (other.gameObject.CompareTag("RoomChange4"))
        {
            scene = "scene 4";
            SceneManager.LoadScene(7);
        }
        
        if (other.gameObject.CompareTag("RoomChange5"))
        {
            scene = "scene 4";
            SceneManager.LoadScene(8);
        }

        

       
    }


    void Hiding()
    {
        if (inZone == true && isHiding == false)
        {
            if (Input.GetKeyDown("w"))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                isHiding = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                gameObject.transform.position = hide.gameObject.transform.position;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            }
        }
        else if (inZone == true && isHiding == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.transform.position = hide.gameObject.transform.position;

            if (Input.GetKeyDown("w"))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                isHiding = false;
            }
        }
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector2 temp = gameObject.transform.localScale;
        temp.x = temp.x * -1;
        gameObject.transform.localScale = temp;
    }

    void StateManager()
    {
        switch (s)
        {
            case State.Walking:
                {

                    //animate.SetBool("Walk", true);
                       
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        s = State.Jumping;
                        Jump();
                    }

                    if(armed && Input.GetMouseButtonDown(0))
                    {
                        s = State.Attacking;
                    }

                    sideMovement = Input.GetAxis("Horizontal") * speed;
                    //if (sideMovement == 0) { animate.SetBool("KeyDown", false); }
                    //else { animate.SetBool("KeyDown", true); }

                    control.velocity = new Vector2(sideMovement, control.velocity.y);


                    if (sideMovement < 0 && faceRight == true)
                    {
                        flip();
                    }
                    else if (sideMovement > 0 && faceRight == false)
                    {
                        flip();
                    }

                    if (inZone == true && isHiding == false)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = false;
                            isHiding = true;
                            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                            gameObject.transform.position = hide.gameObject.transform.position;
                            s = State.Hiding;
                        }
                    }

                    break;
                }
            case State.Standing:
                {
                    //animate.SetBool("Stand", true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        s = State.Jumping;
                        Jump();
                    }

                    if (armed && Input.GetMouseButtonDown(0))
                    {
                        s = State.Attacking;
                    }
                    sideMovement = Input.GetAxis("Horizontal") * speed;

                    control.velocity = new Vector2(sideMovement, control.velocity.y);
                    //animate.SetFloat("Speed", Mathf.Abs(sideMovement));

                   if(Input.GetKeyDown("d"))
                    {
                        Debug.Log("not in her");
                        s = State.Walking;
                    }

                    if (inZone == true && isHiding == false)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = false;
                            isHiding = true;
                            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                            gameObject.transform.position = hide.gameObject.transform.position;
                            s = State.Hiding;

                        }
                    }

                    break;
                }

            case State.Hiding:
                {
                   
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    gameObject.GetComponent<Rigidbody2D>().isKinematic= true;

                    gameObject.transform.position = safe.transform.position;
                    if (inZone == true && isHiding == true)
                    {

                        if (Input.GetKeyDown("w"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = true;
                            isHiding = false;
                            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                            
                            s = State.Standing;
                        }
                    }
                    break;
                }
            case State.Jumping:
                {
                   // animate.SetBool("Hide", true);
                    if (ground == true)
                    {
                        s = State.Standing;
                    }

                    if (armed && Input.GetMouseButtonDown(0))
                    {
                        s = State.Attacking;
                    }

                    sideMovement = Input.GetAxis("Horizontal") * speed;

                    control.velocity = new Vector2(sideMovement, control.velocity.y);
                    //animate.SetFloat("Speed", Mathf.Abs(sideMovement));

                    if (sideMovement == 0)
                    {
                        //animate.SetBool("KeyDown", false);
                        s = State.Standing;
                    }
                    else
                    {
                       // animate.SetBool("KeyDown", true);
                        s = State.Walking;
                    }

                    if (inZone == true && isHiding == false)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = false;
                            isHiding = true;
                            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                            gameObject.transform.position = hide.gameObject.transform.position;
                            s = State.Hiding;

                        }
                    }
                    break;
                }

            case State.Attacking:
                {
                   // animate.SetBool("Attack", true);
                    if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
                    {
                        s = State.Walking;
                    }
                    //animate.Play("Attack");
                    break;
                }

            case State.Text:
                {
                    
                    control.velocity = Vector3.zero;
                    time--;

                    if(txt.gameObject.GetComponent<TextBox>().done == true)
                    {
                        s = State.Standing;
                    }

                    break;
                }
            case State.Dead:
                {
                    //animate.SetBool("Dead", true);


                    break;
                }
        

        }
    }
}

