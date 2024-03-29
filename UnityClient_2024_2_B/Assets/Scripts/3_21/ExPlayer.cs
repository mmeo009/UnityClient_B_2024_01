using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;   // 플레이어 체력

    public void takeDamage(int damage)
    {
        // 플레이어 체력 감소
        health -= damage;

        Debug.Log($"플레이어의 체력 : {health}");

        // 플레이어의 체력이 0 이하로 떨어졌을 때 사망 처리
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // 사망 처리 로직 추가
        Debug.Log("아아...그는 갔습니다...");
    }
}
