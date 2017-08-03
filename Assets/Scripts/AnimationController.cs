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
        if (!enemy.isSlapActive)
        {
            switch (enemy.enemyState)
            {
                case BaseEnemy.EnemyState.Idle:
                    //animator.SetTrigger("iswalking");
                    break;
                case BaseEnemy.EnemyState.Walk:
                    animator.SetTrigger("iswalking");
                    break;
                case BaseEnemy.EnemyState.Attack:
                    animator.SetTrigger("throw");
                    break;
            }
        }
    }
}
