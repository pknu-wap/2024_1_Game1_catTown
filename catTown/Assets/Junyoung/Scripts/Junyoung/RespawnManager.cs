using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance; // 싱글톤 인스턴스

    public PlayerController player;
    public Main_PMove main_PMove;
    public Monster monster;
    public GameObject gameOverPanel; // Game Over UI 패널

    void Awake()
    {
        //player = GetComponent<PlayerController>();
        //// RespawnManager의 인스턴스가 이미 있으면 새로 생성되는 것을 방지합니다.
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // 씬을 이동해도 오브젝트를 파괴하지 않습니다.
        //}
        //else
        //{
        //    Destroy(gameObject); // 이미 인스턴스가 있는 경우 중복된 오브젝트를 파괴합니다.
        //}
    }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        main_PMove.Respawn();
        //monster.Respawn();
        gameOverPanel.SetActive(false); // 리스폰할 때 Game Over 패널 비활성화
        Time.timeScale = 1.0f;
    }

}
