using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBrother : MonoBehaviour {

    public float speed;
    public float offset;

    //The distance before the AI detects enemies
    public float maxEnemyDistance;

    //The distance AI loses sight of player
    public float minTargetDistance;

    private GameObject target;
    private GameObject enemy;

    public enum BehaviourState
    {
        Safe,
        Scared
    }

    //Declare the state machine
    public BehaviourState behaviourState;

	// Use this for initialization
	void Start ()
    {
        //Declaring the game objects
        target = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Checks to see if the AI can move
        if (behaviourState != BehaviourState.Scared)
        {
            Movement();
        }

        //These functions will be called every frame
        AILogic();
        AIBehaviour();
	}

    void Movement()
    {
        //getting the distance bewteen the target and AI
        Vector3 delta = transform.position-target.transform.position;
        //set the distance to 1 unit
        delta.Normalize();

        //The AI will move towards the target
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position+delta*offset, speed * Time.deltaTime);
    }

    void AILogic()
    {
        //Calculating the distances between the AI and other objects
        var targetDiff = (target.transform.position - transform.position).magnitude;
        var enemyDiff = (enemy.transform.position - transform.position).magnitude;

        //Checking to see if the AI is between the parameters
        if (enemyDiff <= maxEnemyDistance || targetDiff >= minTargetDistance)
        {
            behaviourState = BehaviourState.Scared;
        }
        else
        {
            behaviourState = BehaviourState.Safe;
        }
    }

    void AIBehaviour()
    {
        //Changing between behaviour states
        switch (behaviourState)
        {
            case BehaviourState.Safe:
                break;
            case BehaviourState.Scared:
                break;
        }
    }
}
