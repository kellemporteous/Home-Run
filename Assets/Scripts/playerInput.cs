using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInput : MonoBehaviour {
    public float speed;
    public Transform right;
    public Transform left;
    public Transform up;
    public Transform down;
    public bool jumping;
    public GameObject jumpPos;
    public float jumpSpeed;
    public float startjumpspeed;
    public Rigidbody2D playerRB;
    // public float amountToMove;    // 

    public Text countText;
    public GameObject[] healthImages;
    public int maxHealth;
    public int currentHealth;
    public GameObject spawner;
    public float startTime;

    public bool goingDown;      //wink wink
    public float jumpheight;   //height to jump
    public AudioSource jump;
    public bool test;
    public int WBCOUNT;
    public GameObject balloonPrefab;
    public bool runtimer;
    public bool p1;
   
    public string playerstring;
    public GameObject player2;
    private GameObject player;
    public bool notrunning;
    public float timertime;
    public float runtimerintial;
    public float walkspeed;
    public float runspeed;
    public Animator ani;
    public SpriteRenderer thisspriterenderer;
    public int throwtimer;
    public bool throwbool;
   

    // Use this for initialization
    void Start()
    {
        thisspriterenderer = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
        notrunning = true;
        startjumpspeed = jumpSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        speed = walkspeed;
        if (p1)
        {
            jumpPos = GameObject.FindGameObjectWithTag("jumposP1");
                 
        }
        if (!p1)
        {
            jumpPos = GameObject.FindGameObjectWithTag("jumposP2");

        }
        WBCOUNT = 0;
        maxHealth = healthImages.Length;
        currentHealth = maxHealth;
        spawner = GameObject.FindGameObjectWithTag("spawner");
        startTime = Time.time;
    }



    // Update is called once per frame
    void Update()

    {
        //testing if balloon count goes up after key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R is being pressed");
            //will return minimum of 12, count + 3. 12 will be limit of balloons
            WBCOUNT = Mathf.Min(WBCOUNT + 3, 12);
            SetCountText();
        }
        if (currentHealth <= 0)
        {

            //To do: Google for loop and have the health images reset to active	
            spawner.GetComponent<playerdist>().spawning = true;
            currentHealth = maxHealth;
            startTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentHealth -= 1;
            healthImages[currentHealth].SetActive(false);
        }

        throwtimer -= 1;    
                  

        if (runtimer)
        {
            timertime -= Time.deltaTime * 10;
        }
        if (notrunning)
        {
            speed = walkspeed;
            ani.SetBool("isrunning", false);
        }
        if (!notrunning)
        {
            ani.SetBool("isrunning", true);
            speed = runspeed;
        }


        if ((Input.GetAxis("horizontalP1") == 0f) || (Input.GetAxis("Horizontal") == 0f))
            {
            ani.SetBool("iswalking", false);
            
            if (runtimer && notrunning)
                notrunning = false;
           
        }

        if ((Input.GetAxis("horizontalP1") == 0f && !notrunning || (Input.GetAxis("Horizontal") == 0f && !notrunning)))
        {
            if (timertime <= 1)
            {
                runtimer = false;
                timertime = 0;
                notrunning = true;
                
            }
        }

        if ((Input.GetAxis("horizontalP1") == -1f && p1 && transform.position.x <= right.position.x))
        {
            if (p1)
            {
                transform.position = new Vector2(transform.position.x + speed / 100, transform.position.y);
            }
            thisspriterenderer.flipX = false;
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }

            if (!notrunning)

            {


                timertime = runtimerintial;
            }
        }
        if ((Input.GetAxis("horizontalP2") == -1f && !p1))
        {
            if (!p1)
            {
                player2.transform.position = new Vector2(player2.transform.position.x + speed / 100,transform.position.y);
            }
            thisspriterenderer.flipX = false;
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }



           
           
        }

        if ((Input.GetAxis("horizontalP1") == 1f && p1 && transform.position.x >= left.position.x))
        {
            thisspriterenderer.flipX = true;
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }

            if (p1)
                transform.position = new Vector2(transform.position.x - (speed - 1) / 100, transform.position.y);
            if (!p1)
                transform.position = new Vector2(transform.position.x - (speed - 1) / 100, transform.position.y);
        }

        if ((Input.GetAxis("horizontalP2") == 1f && !p1 && transform.position.x >= left.position.x))
        {
            thisspriterenderer.flipX = true;
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }

           
            if (!p1)

                transform.position = new Vector2(transform.position.x - (speed - 1) / 100, transform.position.y);
        }

        if ((Input.GetAxis("verticalP1") == -1f  && p1 && transform.position.y <= up.position.y))
        {

            if (!runtimer && notrunning)
            {
               // runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }


            if (p1)
                transform.position = new Vector2(transform.position.x, transform.position.y + speed / 200);
            if (!p1)

                transform.position = new Vector2(transform.position.x, transform.position.y + speed / 200);
        }

        if ((Input.GetAxis("verticalP2") == -1f && !p1 && transform.position.y <= up.position.y))
        {

            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }


            if (p1)
                transform.position = new Vector2(transform.position.x, transform.position.y + speed / 200);
            if (!p1)

                transform.position = new Vector2(transform.position.x, transform.position.y + speed / 200);
        }


        if ((Input.GetAxis("verticalP1") == 1f && p1 && transform.position.y >= down.position.y))
        {
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }
            if (p1)
                transform.position = new Vector2 (transform.position.x, transform.position.y - speed / 200);
            if(!p1)

               transform.position = new Vector2(transform.position.x, transform.position.y - speed / 200);
        }
        if ((Input.GetAxis("verticalP2") == 1f && !p1 && transform.position.y >= down.position.y))
        {
         
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }
            
               
            if (!p1)

                    transform.position = new Vector2(transform.position.x, transform.position.y - speed / 200);
        }


        if ((Input.GetButtonDown("B_buttonP1")  && WBCOUNT > 0 && p1) || (Input.GetKeyDown(KeyCode.KeypadEnter) && WBCOUNT > 0))
        {
           if (p1 && throwtimer <= 0)
            ani.SetTrigger("throw");
            Instantiate(balloonPrefab, gameObject.transform.position, Quaternion.identity);
            WBCOUNT -= 1;
            throwtimer = 10;
            SetCountText();
        }
        if (Input.GetButtonDown("B_buttonP2") && WBCOUNT > 0 && !p1)
        {
            if (!p1 && throwtimer <= 0)
            {
                ani.SetTrigger("throw");
                Instantiate(balloonPrefab, transform.position, Quaternion.identity);
                WBCOUNT -= 1;
                throwtimer = 10;
                SetCountText();
            }
        }





    }
    //Counts when player collects ballons, but doesn't exceed the limit set
    void SetCountText ()
    {
        countText.text = "" + WBCOUNT.ToString();
    }

  public void  OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "waterball" )
       {
          print(other.gameObject.name);
         WBCOUNT += 1;
         Destroy(other.gameObject);
       }
        //Checking if enemy gameobject has hit player, if so lose 1 health and 1 healthImage
        if (other.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
            healthImages[currentHealth].SetActive(false);
        }
    }
    
    void FixedUpdate()
        {

        


        if ((Input.GetButtonDown("A_buttonP1")&& Input.GetAxis("verticalP1") == -1f && p1 && jumping == false && !goingDown))
        {
            jumpPos.transform.position = new Vector2(transform.position.x, transform.position.y);
            // jump.Play();

            //jumpPos.transform.position = new Vector2( transform.position.x,playerRB.transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpSpeed - Time.deltaTime));
            jumping = true;
        }
        if ((Input.GetButtonDown("A_buttonP2") && Input.GetAxis("verticalP2") == -1f && !p1 && jumping == false && !goingDown))
        {
            jumpPos.transform.position = new Vector2(transform.position.x, transform.position.y);
            // jump.Play();

            //jumpPos.transform.position = new Vector2( transform.position.x,playerRB.transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpSpeed - Time.deltaTime));
            jumping = true;


        }

        if (jumping  && !goingDown && p1)
        {
            if (transform.position.y > jumpPos.transform.position.y + jumpheight / 100)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, -jumpSpeed ));
                goingDown = true;
               
            }


        }
        if (jumping && !goingDown && !p1)
        {
            if (gameObject.transform.position.y > jumpPos.transform.position.y + jumpheight / 100)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, -jumpSpeed));
                goingDown = true;

            }


        }

        if (goingDown &&  transform.position.y <= jumpPos.transform.position.y)

        {
            
           gameObject.GetComponent<Rigidbody2D> ().transform.position = new Vector2(transform.position.x, jumpPos.transform.position.y);
           gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            

            jumping = false;
            goingDown = false;
        }
        }
}
