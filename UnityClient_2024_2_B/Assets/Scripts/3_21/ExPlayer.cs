using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;   // �÷��̾� ü��

    public void takeDamage(int damage)
    {
        // �÷��̾� ü�� ����
        health -= damage;

        Debug.Log($"�÷��̾��� ü�� : {health}");

        // �÷��̾��� ü���� 0 ���Ϸ� �������� �� ��� ó��
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // ��� ó�� ���� �߰�
        Debug.Log("�ƾ�...�״� �����ϴ�...");
    }
}
