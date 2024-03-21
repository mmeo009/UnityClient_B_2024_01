using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;

    private int damage = 20;

    private void AttackPlayer(ExPlayer player)
    {
        // player.health -= damage(health의 보호수준 때문에 접근 불가능)
        player.takeDamage(damage);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("플레이어 따끔!");
            if (targetPlayer != null)
            {
                AttackPlayer(targetPlayer);
            }
        }
    }
}
