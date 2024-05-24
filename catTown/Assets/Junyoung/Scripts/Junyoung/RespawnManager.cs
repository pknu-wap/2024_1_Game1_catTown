using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public PlayerController player;
    public Main_PMove main_PMove;
    public Monster monster;
    public GameObject gameOverPanel; // Game Over UI �г�

    void Update()
    {
        // �÷��̾ �׾��� �� Game Over UI�� Ȱ��ȭ�մϴ�.
        if (player != null && main_PMove.hp <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void RespawnAll()
    {
        player.Respawn();
        monster.Respawn();
        gameOverPanel.SetActive(false); // �������� �� Game Over �г� ��Ȱ��ȭ
        Time.timeScale = 1.0f;
    }
}
