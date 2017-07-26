using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




    // Use this for initialization
    void Start()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
        
        startjumpspeed = jumpSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }
        


    // Update is called once per frame
    void Update()
        
    {
       
        
        
        if ((Input.GetAxis("horizontalP1") == -1f || Input.GetAxis("horizontalP2") == -1f) && transform.position.x <= right.position.x )
        {
            if (p1)
            playerRB.transform.position = new Vector2(playerRB.transform.position.x + speed / 100, player.transform.position.y);
            if (!p1)
            {
            player2.transform.position = new Vector2(player2.transform.position.x + speed / 100, player.transform.position.y); ;
            }
        }

        if ((Input.GetAxis("horizontalP1") == 1f || Input.GetAxis("horizontalP2") ==1f) && transform.position.x >= left.position.x)
        {
            
            if (p1)
                playerRB.transform.position =  new Vector2(playerRB.transform.position.x - (speed - 1) / 100 , player.transform.position.y );
            if (!p1)
            
                player2.transform.position = new Vector2(player2.transform.position.x - (speed - 1) / 100, player.transform.position.y);
        }

        if ((Input.GetAxis ("verticalP1") == -1f || Input.GetAxis("verticalP2") == -1f) &&  player.transform.position.y <= up.position.y)
        {
            if (p1)
                playerRB.transform.position = new Vector2(playerRB.transform.position.x, player.transform.position.y + speed / 200);
            if (!p1)

                player2.transform.position = new Vector2(player2.transform.position.x, player.transform.position.y + speed / 200);
        }

        if ((Input.GetAxis("verticalP1") == 1f || Input.GetAxis("verticalP2") ==1f) && player.transform.position.y >= down.position.y)
        {
            if (p1)
                playerRB.transform.position = new Vector2(playerRB.transform.position.x, player.transform.position.y - speed / 200);
            if(!p1)

                player2.transform.position = new Vector2(player2.transform.position.x, player.transform.position.y - speed / 200);
        }

        if ((Input.GetButtonDown("B_buttonP1") || Input.GetButtonDown("B_buttonP2") && WBCOUNT != 0))
        {
            Instantiate(balloonPrefab,gameObject.transform.position, Quaternion.identity);
            WBCOUNT -= 1;
        }


       

       
       


    }

  public void  OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "waterball" )
       {
          print(other.gameObject.name);
         WBCOUNT += 1;
         Destroy(other.gameObject);
       }
    }
    void FixedUpdate()
        {
         if ((Input.GetButtonDown ("A_buttonP1") || Input.GetButtonDown("A_buttonP2")) && jumping == false && !goingDown)
        {
            jumpPos.transform.position = new Vector2(transform.position.x, transform.position.y);
            // jump.Play();
          
            //jumpPos.transform.position = new Vector2( transform.position.x,playerRB.transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpSpeed - Time.deltaTime));
            jumping = true;
            

        }
        if (jumping  && !goingDown)
        {
            if (player.transform.position.y > jumpPos.transform.position.y + jumpheight / 100)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, -jumpSpeed ));
                goingDown = true;
               
            }

            
        }

        if (goingDown &&  transform.position.y <= jumpPos.transform.position.y)

        {
            
            playerRB.GetComponent<Rigidbody2D> ().transform.position = new Vector2(transform.position.x, jumpPos.transform.position.y);
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            

            jumping = false;
            goingDown = false;
        }
        }
}
