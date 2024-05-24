using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance; // �̱��� �ν��Ͻ�

    public PlayerController player;
    public Main_PMove main_PMove;
    public Monster monster;
    public GameObject gameOverPanel; // Game Over UI �г�
    [SerializeField] Transform playerRespawnPoint;

    void Awake()
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("e");
            Ret();
        }
    }

    public void RespawnAll()
    {
        

        // ������ ������ �۾���...

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        main_PMove.hp = 10;
       
        // �÷��̾��� ��ġ�� ������ ����Ʈ�� �̵��մϴ�.
        if (player != null && playerRespawnPoint != null)
        {
            player.transform.position = playerRespawnPoint.position;
            Debug.Log("��ġ����");
        }
        Time.timeScale = 1.0f;
        //player.Respawn();
        //monster.Respawn();
        //gameOverPanel.SetActive(false); // �������� �� Game Over �г� ��Ȱ��ȭ
        //Time.timeScale = 1.0f;
    }
    public void Ret()
    {
        Debug.Log("Ŭ��");
        GameObject targetObject = GameObject.Find("Player"); // ������ ������Ʈ�� �̸����� �˻�

        if (targetObject != null && playerRespawnPoint != null)
        {
            targetObject.transform.position = playerRespawnPoint.position;
            Debug.Log("��ġ����");
        }
    }
}
