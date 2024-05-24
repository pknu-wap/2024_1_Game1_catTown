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
    [SerializeField] Transform playerRespawnPoint;

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
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("e");
            Ret();
        }
    }

    public void RespawnAll()
    {
        

        // 나머지 리스폰 작업들...

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        main_PMove.hp = 10;
       
        // 플레이어의 위치를 리스폰 포인트로 이동합니다.
        if (player != null && playerRespawnPoint != null)
        {
            player.transform.position = playerRespawnPoint.position;
            Debug.Log("위치변경");
        }
        Time.timeScale = 1.0f;
        //player.Respawn();
        //monster.Respawn();
        //gameOverPanel.SetActive(false); // 리스폰할 때 Game Over 패널 비활성화
        //Time.timeScale = 1.0f;
    }
    public void Ret()
    {
        Debug.Log("클릭");
        GameObject targetObject = GameObject.Find("Player"); // 변경할 오브젝트의 이름으로 검색

        if (targetObject != null && playerRespawnPoint != null)
        {
            targetObject.transform.position = playerRespawnPoint.position;
            Debug.Log("위치변경");
        }
    }
}
