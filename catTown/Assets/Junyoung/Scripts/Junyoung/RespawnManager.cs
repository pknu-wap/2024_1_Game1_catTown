using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public PlayerController player;
    public Main_PMove main_PMove;
    public Monster monster;
    public GameObject gameOverPanel; // Game Over UI 패널

    void Update()
    {
        // 플레이어가 죽었을 때 Game Over UI를 활성화합니다.
        if (player != null && main_PMove.hp <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void RespawnAll()
    {
        player.Respawn();
        monster.Respawn();
        gameOverPanel.SetActive(false); // 리스폰할 때 Game Over 패널 비활성화
        Time.timeScale = 1.0f;
    }
}
