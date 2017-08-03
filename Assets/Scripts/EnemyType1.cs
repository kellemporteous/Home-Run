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
            isSlapActive = false;
            isAttacking = false;
            
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyState != EnemyState.Special)
        {
            base.OnCollisionEnter2D(collision);
        }
        if (enemyState == EnemyState.Special)
        {
            if (collision.gameObject == player)
            {
                //if true, reduce the amount of health by damage
                playerInfo.currentHealth = playerInfo.currentHealth - (damage * 2);
            }
        }
    }

}
