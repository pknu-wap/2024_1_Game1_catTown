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
    // Start is called before the first frame update
    void Start()
    {
        // Player ��ũ��Ʈ�� ����� �����Ǿ����� Ȯ���մϴ�
        if (main_PMove == null)
        {
            Debug.LogError("Player ��ũ��Ʈ�� ã�� �� �����ϴ�!");
        }
        //if (playerRespawn == null)
        //{
        //    Debug.LogError("PlayerRespawn Transform�� �������� �ʾҽ��ϴ�!");
        //}
    }

    // Update is called once per frame
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

    //public void Respawn()
    //{
    //    Debug.Log("������ ����");
    //    Debug.Log("������ ����Ʈ ��ġ: " + playerRespawn.position);
    //    Debug.Log("�÷��̾� ���� ��ġ: " + playertransform.position);

    //    if (navMeshAgent != null)
    //    {
    //        navMeshAgent.enabled = false; // NavMeshAgent�� ��Ȱ��ȭ�մϴ�.
    //    }

    //    playertransform.position = playerRespawn.position;
    //    rigidbody.position = playerRespawn.position;
    //    rigidbody.velocity = Vector3.zero;

    //    if (navMeshAgent != null)
    //    {
    //        navMeshAgent.Warp(playerRespawn.position); // NavMeshAgent�� ���ο� ��ġ�� �����մϴ�.
    //        navMeshAgent.enabled = true; // NavMeshAgent�� �ٽ� Ȱ��ȭ�մϴ�.
    //    }

    //    Debug.Log("�÷��̾� ������ �� ��ġ: " + playertransform.position);
    //    Debug.Log("������ �Ϸ�");

    //    if (main_PMove != null)
    //    {
    //        main_PMove.hp = 10;  // ü���� �ִ�ġ�� ȸ��
    //    }
    //}
}
