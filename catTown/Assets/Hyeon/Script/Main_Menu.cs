using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    
    public static Main_Menu mm;

    public void Awake()
    {
        if(mm == null)
        {
            
            mm = this;
        }
    }
    
    public enum GameState
    {
        Ready,
        Run,
        Pause,
        GameOver
    }

    public GameState gState;

    public GameObject gameLabel;

    Text gameText;

    Main_PMove Player;

    public GameObject gameOption;

    public void Resume()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1.0f;
        gState = GameState.Run;
        state = true;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Open_Close()
    {   
        if(Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown(KeyCode.M))
        //if(Input.GetButtonDown("Cancel"))
        {
            if(state == true)
            {
                gameOption.SetActive(true);
                Time.timeScale = 0f;
                gState = GameState.Pause;
                state = false;
            }
            else
            {
                gameOption.SetActive(false);
                Time.timeScale = 1.0f;
                gState = GameState.Run;
                state = true;
            }
        }
        
    }

    public bool state;

    void Opening()
    {   
        if(Input.GetKeyDown(KeyCode.M))
        //if(Input.GetButtonDown("Escape"))
        {
            if(state == true)
            {
                gameOption.SetActive(true);
                Time.timeScale = 0f;
                gState = GameState.Pause;
                state = false;
            }
            else
            {
                gameOption.SetActive(false);
                Time.timeScale = 1.0f;
                gState = GameState.Run;
                state = true;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Main_PMove>();

        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();

        StartCoroutine(ReadytoStart());

        state = true;

    }

    IEnumerator ReadytoStart(){

        yield return new WaitForSeconds(1f);

        gState = GameState.Run;
    }
    // Update is called once per frame
    void Update()
    {
        if(Player.hp <= 0)
        {
            gameLabel.SetActive(true);
            gState = GameState.GameOver;
        }

        Opening();

    }
    
}
