using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManagerClone : MonoBehaviour
{

    public PlayerSpawner playerSpawner;
    public GameObject gameOverPanel;

    private Main_PMove main_PMove;

    void Start()
    {
        // 플레이어를 스폰하고 main_PMove를 설정
        GameObject player = playerSpawner.SpawnPlayer();
        AssignMainPMove(player);
    }

    void Update()
    {
        if (main_PMove != null && main_PMove.hp <= 0)
        {
            Debug.Log("gameover UI Active");
            gameOverPanel.SetActive(true);
        }
    }

    public void RespawnAll()
    {
        // 씬을 다시 로드한 후, 플레이어를 다시 찾고 리스폰
        SceneManager.LoadScene("ApartmentScene");
        StartCoroutine(FindAndRespawnPlayer());
        gameOverPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void AssignMainPMove(GameObject player)
    {
        if (player != null)
        {
            main_PMove = player.GetComponent<Main_PMove>();
        }
    }

    private IEnumerator FindAndRespawnPlayer()
    {
        yield return new WaitForEndOfFrame(); // 씬 로드가 완료될 때까지 대기

        // 씬에서 Main_PMove 오브젝트를 찾음
        GameObject player = GameObject.FindObjectOfType<Main_PMove>().gameObject;
        AssignMainPMove(player);
        if (main_PMove != null)
        {
            main_PMove.Respawn();
        }
    }
}
