using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance; // �̱��� �ν��Ͻ�

    public PlayerController player;
    public Main_PMove main_PMove;
    //public Monster monster;
    public GameObject gameOverPanel; // Game Over UI �г�

    void Start()
    {
        //player = GetComponent<PlayerController>();
        //// RespawnManager�� �ν��Ͻ��� �̹� ������ ���� �����Ǵ� ���� �����մϴ�.
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // ���� �̵��ص� ������Ʈ�� �ı����� �ʽ��ϴ�.
        //}
        //else
        //{
        //    Destroy(gameObject); // �̹� �ν��Ͻ��� �ִ� ��� �ߺ��� ������Ʈ�� �ı��մϴ�.
        //}
    }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        main_PMove.Respawn();
        //monster.Respawn();
        gameOverPanel.SetActive(false); // �������� �� Game Over �г� ��Ȱ��ȭ
        Time.timeScale = 1.0f;
    }

}
