using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;

    public PlayerController player;
    public Main_PMove main_PMove;
    public GameObject gameOverPanel;

 
    void Start()
    {
    }

    void Update()
    {
        if (player != null && main_PMove.hp <= 0)
        {
            Debug.Log("gameover UI Active");
            gameOverPanel.SetActive(true);
        }

    }

    public void RespawnAll()
    {
        SceneManager.LoadScene("ApartmentScene");
    }

}
