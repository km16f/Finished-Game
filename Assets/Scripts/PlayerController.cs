 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class PlayerController : MonoBehaviour
{
   public string scene;

    public float speed, sideMovement = 0.0f;
    private Rigidbody2D control;
    public float jumpforce;
    bool ground;
    bool faceRight = true;
    public Animator animate;
    public bool isHiding;
    int collisionnum = 0;
    public GameObject player, temp,hide, txt;
    bool inZone = false;
    public Image item;
    public int time;
   public Sprite back, normal;

    bool armed;
    bool keyed;
 
    //public int s;

    enum State { Standing, Walking, Jumping, Hiding, Attacking, Text };
    State s;
    //public Text wins;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        speed = 10;
        s = 0;
        hide = GameObject.FindGameObjectWithTag("Hiding");
        back = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Backwards_Down.png",typeof (Sprite));
        normal = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Character5.png", typeof(Sprite));
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
            gameObject.GetComponent<SpriteRenderer>().sprite = back;
            
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

        if (other.gameObject.CompareTag("Win"))
        {
            temp = GameObject.FindWithTag("WinTxt");
            temp.gameObject.GetComponent<Canvas>().enabled = true;
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

            }
        }
        else if (inZone == true && isHiding == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.transform.position = hide.gameObject.transform.position;

            if (Input.GetKeyDown("w"))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
                    gameObject.GetComponent<SpriteRenderer>().sprite = normal;
                    
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        s = State.Jumping;
                        Jump();
                    }

                    sideMovement = Input.GetAxis("Horizontal") * speed;
                    if (sideMovement == 0) { animate.SetBool("KeyDown", false); }
                    else { animate.SetBool("KeyDown", true); }

                    control.velocity = new Vector2(sideMovement, control.velocity.y);

                    animate.SetFloat("Speed", Mathf.Abs(sideMovement));

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
                    
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        s = State.Jumping;
                        Jump();
                    }

                    sideMovement = Input.GetAxis("Horizontal") * speed;

                    control.velocity = new Vector2(sideMovement, control.velocity.y);
                    animate.SetFloat("Speed", Mathf.Abs(sideMovement));

                    if (sideMovement == 0)
                    {
                        animate.SetBool("KeyDown", false);
                        s = State.Standing;
                    }
                    else
                    {
                        animate.SetBool("KeyDown", true);
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
                    if (inZone == true && isHiding == true)
                    {

                        if (Input.GetKeyDown("w"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = true;
                            isHiding = false;
                            s = State.Standing;
                        }
                    }
                    break;
                }
            case State.Jumping:
                {
                    
                    if (ground == true)
                    {
                        s = State.Standing;
                    }

                    sideMovement = Input.GetAxis("Horizontal") * speed;

                    control.velocity = new Vector2(sideMovement, control.velocity.y);
                    animate.SetFloat("Speed", Mathf.Abs(sideMovement));

                    if (sideMovement == 0)
                    {
                        animate.SetBool("KeyDown", false);
                        s = State.Standing;
                    }
                    else
                    {
                        animate.SetBool("KeyDown", true);
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
        

        }
    }
}

