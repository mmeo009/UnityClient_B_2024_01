using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;

    private int damage = 20;

    private void AttackPlayer(ExPlayer player)
    {
        // player.health -= damage(health�� ��ȣ���� ������ ���� �Ұ���)
        player.takeDamage(damage);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�÷��̾� ����!");
            if (targetPlayer != null)
            {
                AttackPlayer(targetPlayer);
            }
        }
    }
}
