using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Main_PMove main_PMove;

    private void Awake()
    {
        // Player 스크립트를 같은 GameObject에서 찾습니다
        main_PMove = GetComponent<Main_PMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Player 스크립트가 제대로 참조되었는지 확인합니다
        if (main_PMove == null)
        {
            Debug.LogError("Player 스크립트를 찾을 수 없습니다!");
        }
        //if (playerRespawn == null)
        //{
        //    Debug.LogError("PlayerRespawn Transform이 설정되지 않았습니다!");
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
                // 죽음
            }
        }
    }

    //public void Respawn()
    //{
    //    Debug.Log("리스폰 시작");
    //    Debug.Log("리스폰 포인트 위치: " + playerRespawn.position);
    //    Debug.Log("플레이어 현재 위치: " + playertransform.position);

    //    if (navMeshAgent != null)
    //    {
    //        navMeshAgent.enabled = false; // NavMeshAgent를 비활성화합니다.
    //    }

    //    playertransform.position = playerRespawn.position;
    //    rigidbody.position = playerRespawn.position;
    //    rigidbody.velocity = Vector3.zero;

    //    if (navMeshAgent != null)
    //    {
    //        navMeshAgent.Warp(playerRespawn.position); // NavMeshAgent를 새로운 위치로 워프합니다.
    //        navMeshAgent.enabled = true; // NavMeshAgent를 다시 활성화합니다.
    //    }

    //    Debug.Log("플레이어 리스폰 후 위치: " + playertransform.position);
    //    Debug.Log("리스폰 완료");

    //    if (main_PMove != null)
    //    {
    //        main_PMove.hp = 10;  // 체력을 최대치로 회복
    //    }
    //}
}
