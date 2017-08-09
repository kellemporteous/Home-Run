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
    public int count;
    public bool PlaySound = false;

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
    public GameObject[] p2infoobjs;
    public bool notrunning;
    public float timertime;
    public float runtimerintial;
    public float walkspeed;
    public float runspeed;
    public Animator ani;
    public SpriteRenderer thisspriterenderer;
    public int throwtimer;
    public bool throwbool;
    public Text wbcounter;
    public bool iswalking;
    public bool isslapping;
    

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
        count = 0;
       
    }



    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetButtonDown("A_buttonP1"))
        {
            isslapping = true;
            ani.SetBool("throw", true);
            
        }
      
        if (!player2.activeInHierarchy && Input.GetButtonDown ("startbuttonP2"))
        {
         
            foreach (GameObject i in p2infoobjs)
            {
                i.SetActive (true);
            }
            player2.SetActive(true);
           

        }

        string wbcountstring = WBCOUNT.ToString();
        wbcounter.text = wbcountstring;

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


        if ((Input.GetAxis("horizontalP1") == 0f)&& p1)
        {
            ani.SetBool("iswalking", false);

            if (runtimer && notrunning)
                notrunning = false;

        }
        if ((Input.GetAxis("horizontalP2") == 0f) && !p1)
        {
            ani.SetBool("iswalking", false);

            if (runtimer && notrunning)
                notrunning = false;

        }



        if ((Input.GetAxis("horizontalP1") == 0f && !notrunning))
        {
            if (timertime <= 1)
            {
               
                gameObject.GetComponent<audioMng>().iswalking = false;
                
                runtimer = false;
                timertime = 0;
                notrunning = true;
                
            }
        }

        if (Input.GetAxis("verticalP1") ==  0f)
        {
            

                gameObject.GetComponent<audioMng>().iswalking = false;
            
        }


                if (((Input.GetAxis("horizontalP1") == -1f || Input.GetKey (KeyCode.RightArrow)) && p1 && transform.position.x <= right.position.x))
        {

            gameObject.GetComponent<audioMng>().iswalking = true;
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
       
        if ((Input.GetAxis("horizontalP2") == -1f  && !p1))
        {
            gameObject.GetComponent<audioMng>().iswalking = true;
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

        if (((Input.GetAxis("horizontalP1") == 1f || Input.GetKey(KeyCode.LeftArrow)) && p1 && transform.position.x >= left.position.x))
        {
            gameObject.GetComponent<audioMng>().iswalking = true;
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
            gameObject.GetComponent<audioMng>().iswalking = true;
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

        if (((Input.GetAxis("verticalP1") == -1f || Input.GetKey(KeyCode.UpArrow)) && p1 && transform.position.y <= up.position.y))
        {
            gameObject.GetComponent<audioMng>().iswalking = true;
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
            gameObject.GetComponent<audioMng>().iswalking = true;
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


        if (((Input.GetAxis("verticalP1") == 1f || Input.GetKey(KeyCode.DownArrow)) && p1 && transform.position.y >= down.position.y))
        {
            gameObject.GetComponent<audioMng>().iswalking = true;
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
            gameObject.GetComponent<audioMng>().iswalking = true;
            if (!runtimer && notrunning)
            {
                runtimer = true;
                timertime = runtimerintial;
                ani.SetBool("iswalking", true);
            }
            
               
            if (!p1)

                    transform.position = new Vector2(transform.position.x, transform.position.y - speed / 200);
        }


        if ((Input.GetButtonDown("B_buttonP1") || Input.GetKeyDown(KeyCode.LeftControl) && WBCOUNT != 0 && p1))
        {
            
            if (p1 && throwtimer <= 0)
            ani.SetTrigger("throw");
            Instantiate(balloonPrefab, gameObject.transform.position, Quaternion.identity);
            balloonPrefab.GetComponent<ballonScript>().player = gameObject;
            WBCOUNT -= 1;
            throwtimer = 10;
        }
        if (Input.GetButtonDown("B_buttonP2")  && WBCOUNT != 0 && !p1)
        {
            if (!p1 && throwtimer <= 0)
            {
                ani.SetTrigger("throw");
                Instantiate(balloonPrefab, transform.position, Quaternion.identity);
                balloonPrefab.GetComponent<ballonScript>().player = gameObject;
                WBCOUNT -= 1;
                throwtimer = 10;
            }
        }





    }
    //Counts when player collects ballons, but doesn't exceed the limit set
 void SetCountText ()
    {
        //countText.text = "" + count.ToString();
    }

  public void  OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "waterball" )
       {
        if (PlaySound == false)
            {
                SoundController.instance.BalloonPickup();
                PlaySound = true;
            }
          print(other.gameObject.name);
         WBCOUNT += 6;
         Destroy(other.gameObject);
       }
        if (isslapping == true && other.tag == "Enemy")
        {
            if (PlaySound ==  false)
            {
                if (p1)
                {
                    SoundController.instance.P1slap();
                    PlaySound = true;
                }
                else
                {
                    SoundController.instance.P2slap();
                    PlaySound = true;
                }
            }
            other.GetComponent<BaseEnemy>().health -= 1;
            isslapping = false;
        }
    }
    void FixedUpdate()
        {

        


        if (((Input.GetButtonDown("A_buttonP1")&& Input.GetAxis("verticalP1") == -1f || Input.GetKey(KeyCode.Space)) && p1 && jumping == false && !goingDown))
        {
            if (PlaySound == false)
            {
                SoundController.instance.P1jump();
                PlaySound = true;
            }
            jumpPos.transform.position = new Vector2(transform.position.x, transform.position.y);
            // jump.Play();

            //jumpPos.transform.position = new Vector2( transform.position.x,playerRB.transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpSpeed - Time.deltaTime));
            jumping = true;
        }
        if ((Input.GetButtonDown("A_buttonP2") && Input.GetAxis("verticalP2")  == -1f  && !p1 && jumping == false && !goingDown))
        {
            if (PlaySound == false)
            {
                SoundController.instance.P2jump();
                PlaySound = true;
            }
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
