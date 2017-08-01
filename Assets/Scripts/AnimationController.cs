using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;

    BaseEnemy enemy;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<BaseEnemy>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyAnimation();
	}

    void EnemyAnimation()
    {
        switch (enemy.enemyState)
        {
            case BaseEnemy.EnemyState.Idle:
                animator.SetTrigger("EnemyIdle");
                break;
            case BaseEnemy.EnemyState.Walk:
                animator.SetTrigger("EnemyWalk");
                break;
            case BaseEnemy.EnemyState.Attack:
                animator.SetTrigger("EnemyRun");
                break;
        }
    }
}
