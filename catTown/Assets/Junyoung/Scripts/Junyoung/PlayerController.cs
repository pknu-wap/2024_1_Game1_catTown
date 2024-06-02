using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Main_PMove main_PMove;

    private void Awake()
    {
        // Player ��ũ��Ʈ�� ���� GameObject���� ã���ϴ�
        main_PMove = GetComponent<Main_PMove>();
    }

    void Start()
    {
        // Player ��ũ��Ʈ�� ����� �����Ǿ����� Ȯ���մϴ�
        if (main_PMove == null)
        {
            Debug.LogError("Player ��ũ��Ʈ�� ã�� �� �����ϴ�!");
        }
    }

    void Update()
    {
    }
    public void TakeDamage(int damage)
    {
        if (main_PMove != null)
        {
            main_PMove.hp -= damage;
            if (main_PMove.hp <= 0)
            {
                // ����
            }
        }
    }
}
