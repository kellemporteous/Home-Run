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
    public GameObject cameraOBJ; // physical camera to follow
    public float offset;        //offest for the camera follow
    public float lerpspeed;     //speed of the lerp
    public bool goingDown;      //wink wink
    public float jumpheight;   //height to jump
    public AudioSource jump;
    public bool test;
    public int WBCOUNT;
    public GameObject balloonPrefab;
    public bool runtimer;
    
    


    
    // Use this for initialization
    void Start()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
        cameraOBJ = GameObject.FindGameObjectWithTag("MainCamera");
        startjumpspeed = jumpSpeed;
    }

    // Update is called once per frame
    void Update()
        
    {
       
        Vector3 move = Vector3.MoveTowards(cameraOBJ.transform.position, transform.position * offset, Time.deltaTime * lerpspeed);
        move.y = cameraOBJ.transform.position.y;
        move.z = cameraOBJ.transform.position.z;
        cameraOBJ.transform.position = move;
        //camera.transform.position = new Vector3 (gameObject.transform.position.x  * offset , camera.transform.position.y, camera.transform.position.z);
       
        
        if (Input.GetAxis("horizontal") == -1f && transform.position.x <= right.position.x )
        {
            transform.position = new Vector2(gameObject.transform.position.x + speed / 100, gameObject.transform.position.y);
          
        }

        if (Input.GetAxis("horizontal") == 1f && transform.position.x >= left.position.x)
        {
            test = true;
            transform.position = new Vector2(gameObject.transform.position.x - (speed - 1) / 100 , gameObject.transform.position.y );
        }

        if (Input.GetAxis ("vertical") == -1f && gameObject.transform.position.y <= up.position.y)
        {
            transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed / 200);
        }

        if (Input.GetAxis("vertical") == 1f && gameObject.transform.position.y >= down.position.y)
        {
            transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed / 200);
        }

        if (Input.GetButtonDown("B_button") && WBCOUNT != 0)
        {
            Instantiate(balloonPrefab,gameObject.transform.position, Quaternion.identity);
            WBCOUNT -= 1;
        }


        if (goingDown)
        {
            jumpSpeed =  startjumpspeed;
        }
        if (jumping )
        {
            jumpSpeed = jumpSpeed - Time.deltaTime * 50;
        }

        if (Input.GetButton ("A_button") && jumping == false && Input.GetAxis ("vertical") == -1f)
        {
           
            jump.Play();
            jumping = true;
            jumpPos.transform.position = new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpSpeed - Time.deltaTime));
            
        }
        if (jumping == true && !goingDown)
        {
            if (transform.position.y > jumpPos.transform.position.y + jumpheight / 100)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, -jumpSpeed - 5));
                goingDown = true;
            }

            
        }

        if (goingDown && transform.position.y < jumpPos.transform.position.y)

        {
          
           playerRB.GetComponent<Rigidbody2D> ().transform.position = new Vector2(transform.position.x, jumpPos.transform.position.y);
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            jumping = false;
            goingDown = false;
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
}
