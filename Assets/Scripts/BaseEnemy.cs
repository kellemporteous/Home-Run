using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    //Declare game objects needed
    protected GameObject enemy;
    protected GameObject player;
    public GameObject balloonPrefab;

    //Variables needed for the patrol area
    public float radiusX;
    public float radiusY;

    //Variables needed to move in patrol area
    public float positionX;
    public float positionY;

    //Basic variables need
    public float tChange;
    public float speed;
    public int damage;
    public int health;
    public int numWaterBalloons;
    public float visionDistance;
    public float hitDistance;
    //public float targetDistance;

    //Variables needed for the cool down system
    public float coolDown;
    public float coolDownTimer;

    public bool PlaySound = false;

    public float idleCounter;
    //bools that change AI logic
    public bool isAttacking;
    public bool isSpecialActive;
    public bool isSlapping;

    //Vector2 positions declared
    protected Vector2 newPosition;
    protected Vector2 currentPosition;
    protected Vector2 lastPosition;
    protected Vector2 startPosition;


    protected Transform playerLoc;

    //Declaring the playerInfo
    protected PlayerHealth playerInfo;

    public Animator animator;

    //Public enum that holds the different states
    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Special,
        Death
    }

    //Delcaring the EnemyState. Needed/easier to switch states
    public EnemyState enemyState;
    public EnemyState enemyLastState;


    // Use this for initialization
    void Start()
    {
        //setting the variables to game objects
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        //setting playerInfo to be able to call variables and function for the PlayerHealth script
        animator = GetComponent<Animator>();

        //Set enemy state to idle on start
        enemyState = EnemyState.Idle;

        lastPosition = transform.position;
        startPosition = transform.position;


        //setting booleans when the game starts
        isAttacking = true;
        isSpecialActive = false;

    }

    // Update is called once per frame
    public virtual void Update()
    {
       

        // sets targetdistance to the distance bettween the player
        //targetDistance = Vector3.Distance(transform.position, player.transform.position);
        //Setting The current Position

        currentPosition = this.gameObject.transform.position;

        //Setting the max amount of water balloons held at one time
        if (numWaterBalloons >= 3)
        {
            numWaterBalloons = 3;
        }

        if (health <= 0)
        {
            enemyState = EnemyState.Death;
        }

        //functions that need to be called every update
     //   ScanForFriends();
        EnemyBehaviour();
        EnemyLogic();
        FacingDirection();
        enemyLastState = enemyState;

    }

    void Death()
    {
        Destroy(this.gameObject);
    }

    void Idle()
    {
        if (idleCounter > 0)
        {
            idleCounter -= Time.deltaTime;
        }

        if (idleCounter <= 0)
        {
            enemyState = EnemyState.Walk;
        }
    }

    // Function will be called only when enemy state is set to walk

    void Walk()
    {
        //checking if tChnage has been reached
        if (Time.time >= tChange)
        {
            //Picking a random X and Y position bewteen the radius
            positionX = Random.Range(-radiusX, radiusX);
            positionY = Random.Range(-radiusY, radiusY);

            //reassigning a new value to tChange
            tChange = Time.time + Random.Range(1.0f, 3.0f);

            //setting the new X and Y positions to newPosition
            newPosition = new Vector2(positionX, positionY) + startPosition;
        }

        //Move towards new position
        transform.position = Vector2.MoveTowards(currentPosition, newPosition, speed * Time.deltaTime);

        //NOTE: This is a fail safe to make sure the enemies do not move outside of the patrol area
        // Clamp the X position between the radius
        if (positionX >= radiusX || positionX <= -radiusX)
        {
            positionX = Mathf.Clamp(positionX, -radiusX, radiusX);
        }

        // Clamp the Y position between the radius
        if (positionY >= radiusY || positionY <= -radiusY)
        {
            positionY = Mathf.Clamp(positionY, -radiusY, radiusY);
        }

        if (currentPosition == newPosition)
        {
            enemyState = EnemyState.Idle;
            idleCounter += idleCounter;
        }
    
    }
    //Function will only be called when eney state is set to attack
    void Attack()
    {

        // setting the player position to newPosition
        List<GameObject> players = GameObject.FindGameObjectsWithTag("Player").ToList();
        GameObject closestTarget;
        float distance = Mathf.Infinity;


        foreach (GameObject target in players)
        {
            //creating a random variable
            float canThrow = Random.Range(0, 100);


            //getting the distance from the player to the AI
            float playerDiff = target != null ? (target.transform.position - transform.position).magnitude : float.MaxValue; ;

            if (playerDiff < distance)
            {
                closestTarget = target;
                distance = playerDiff;
            }

            //checking to see if isAttacking is true
            if (isAttacking == true)
            {


                //checking if Ai is within hit distance
                if (playerDiff <= hitDistance)
                {
                    //call this function
                    if (PlaySound == false)
                    {
                        SoundController.instance.EnemySlap();
                        PlaySound = true;
                    }
                    Slap();


                }

                //move towards player
                transform.position = Vector2.MoveTowards(currentPosition, target.transform.position, speed * Time.deltaTime);
            }

            //checking to see if isAttacking is true
            else if (isAttacking == false)
            {
                Vector2 toPlayer = (target.transform.position - transform.position).normalized; toPlayer.y = 0;
                //Move away from the player
                transform.position = Vector2.MoveTowards(currentPosition, currentPosition - toPlayer, speed / 2 * Time.deltaTime);
                //Calling cool down function only when is attacking is false
                PlaySound = false;
                CoolDown();
            }

            //checking to see if AI is able to throw a water balloon
            if (canThrow >= 50 && playerDiff >= hitDistance && numWaterBalloons > 0)
            {
                //spawn water balloon
                Instantiate(balloonPrefab, gameObject.transform.position, Quaternion.identity);
                //decrease the number of water balloons being held
                numWaterBalloons -= 1;
            }
        }

    }

    //Function will only be called when enemy state is set to special, use will chnage depending on the child in heriting
   /* public virtual void Special()
    {

    }*/

    //Function that controls when AI tries to hit the player, use will chnage depending on the child in heriting
    public void Slap()
    {
        Debug.Log("Slap");
        isSlapping = true;
        //EndOfSlap();
        //reset cool down
        coolDownTimer = coolDown;
        animator.SetBool("throw", true);

    }

    public void EndOfSlap()
    {
        //set is attacking to false

    }
    public void IsHit()
    {
        animator.SetTrigger("EnemHit");
    }
    //Function controls the amount of AI with vision distance of each other
   /* void ScanForFriends()
    {
        // setting count to 0 everyframe so the same enemy is not counted twice
        int count = 0;
        //Creating a list to sort the amount of enemies seen
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        //foreach stated to see how many enemies are currently in the list
        foreach (GameObject enemy in enemies)
        {
            //checking if an enemy is within vision distance
            if ((enemy.transform.position - transform.position).magnitude <= visionDistance)
            {
                //add 1 increment to count equal to the amount of game objects in the list
                count++;
            }
        }

        // checking if count is higher than 3 and if AI is in correct state
        if (count >= 2 && enemyState == EnemyState.Attack /*&& targetDistance > 2)
        {
            //if true change states
            enemyState = EnemyState.Special;
            isSpecialActive = true;
        }

        // checking if two close to target to throw ballon
        else if (targetDistance < 2)
        {
            //if true change states
            enemyState = EnemyState.Attack;
            isSpecialActive = false;
        }
    }*/

    //Function will control the direction the AI is facing
    void FacingDirection()
    {

        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        if (enemyState != EnemyState.Attack)
        {
            if (lastPosition.x < currentPosition.x)
            {
                rend.flipX = false;
            }

            else if (lastPosition.x > currentPosition.x)
            {
                rend.flipX = true;
            }
            else
            {
                rend.flipX = rend.flipX;
            }
        }

        lastPosition = currentPosition;

        // flips the sprite to look the direction of its target
        if (player.transform.position.x <= currentPosition.x)
        {
            rend.flipX = true;
        }
        else if (player.transform.position.x > currentPosition.x)
        {
            rend.flipX = false;
        }

        
        

    }

    //Function will control the cooldown mechanic
    void CoolDown()
    {
        //checking is the cool down timer is above 0
        if (coolDownTimer > 0)
        {
            //variable is reduces at the same rate of delta time
            coolDownTimer -= Time.deltaTime;
        }

        //checking is the variable is equal or less then 0
        if (coolDownTimer <= 0)
        {
            //set variable to 0
            coolDownTimer = 0;
            //set is active to true
            isAttacking = true;
        }

    }

    //Function controls how the AI will react
    public void EnemyLogic()
    {

        //finding the distance between the player and AI
        float playerDiff = player != null ? (player.transform.position - transform.position).magnitude : float.MaxValue; ;

        //checking if the AI can see the player
        if (playerDiff < visionDistance)
        {
            //if seen then change states
            enemyState = EnemyState.Attack;
        }

        //checking to see if the AI can see the player and is able to react differently
        if (playerDiff <= visionDistance && isSpecialActive == true)
        {
            //if true then change states
            enemyState = EnemyState.Special;
        }

        //checking to see if player existed
       /* if (player == null)
        {
            //if not change states
            enemyState = EnemyState.Idle;
        }*/

    }

    //Function will handle Ai changing between states
    void EnemyBehaviour()
    {
        //switch statement for enemy states
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Walk:
                Walk();
                break;
            case EnemyState.Attack:
                Attack();
                break;
           case EnemyState.Special:
              //  Special();
                break;
            case EnemyState.Death:
                Death();
                break;
        }
    }

    //Function that controls collisions
    public virtual void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //checking if isAttacking is true
        if (isAttacking == true)
        {

            if (isSlapping == true)
            {
            //checking id collision was with player
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("OH MY GEWD");
                collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= damage;
                    isAttacking = false;

                    //if true, reduce the amount of health by damage
                    // playerInfo.currentHealth = playerInfo.currentHealth - damage;
                }
            }

        }
    }
}
