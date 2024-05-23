using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Main_PMove main_PMove;
    [SerializeField] Transform playerRespawn;

    // Start is called before the first frame update
    void Start()
    {
        // Player 스크립트를 같은 GameObject에서 찾습니다
        main_PMove = GetComponent<Main_PMove>();

        // Player 스크립트가 제대로 참조되었는지 확인합니다
        if (main_PMove == null)
        {
            Debug.LogError("Player 스크립트를 찾을 수 없습니다!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 예시로 hp 변수를 출력합니다
        if (main_PMove != null)
        {
            Debug.Log("Player HP: " + main_PMove.hp);
        }
    }
    public void TakeDamage(int damage)
    {
        if (main_PMove != null)
        {
            main_PMove.hp -= damage;
            if (main_PMove.hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // 플레이어가 죽었을 때의 처리
        Respawn();
    }

    public void Respawn()
    {
        // 예시 리스폰 위치 (원하는 위치로 변경)
        transform.position = playerRespawn.position;
        if (main_PMove != null)
        {
            main_PMove.hp = 100;  // 체력을 최대치로 회복
        }
    }
}
