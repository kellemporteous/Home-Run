using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : BaseEnemy {


    public override void Special()
    {
        newPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(currentPosition, newPosition, speed * 2 * Time.deltaTime);
        float playerDiff = (player.transform.position - transform.position).magnitude;

        if (playerDiff <= hitDistance && isAttacking)
        {
            Slap();
            isAttacking = false;
            
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (enemyState != EnemyState.Special)
        {
            base.OnTriggerEnter2D(collision);
        }
        if (enemyState == EnemyState.Special)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("OH MY GEWD SPECIAL");
                //if true, reduce the amount of health by damage
                collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= damage;
            }
        }

    }
}
