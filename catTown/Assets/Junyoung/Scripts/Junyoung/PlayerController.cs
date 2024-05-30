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

    void Start()
    {
        // Player 스크립트가 제대로 참조되었는지 확인합니다
        if (main_PMove == null)
        {
            Debug.LogError("Player 스크립트를 찾을 수 없습니다!");
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
                // 죽음
            }
        }
    }
}
