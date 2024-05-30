// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class Main_Menu : MonoBehaviour
// {
    
//     public static Main_Menu mm;

//     public void Awake()
//     {
//         if(mm == null)
//         {
            
//             mm = this;
//         }
//     }
    
//     public enum GameState
//     {
//         Ready,
//         Run,
//         Pause,
//         GameOver
//     }

//     public GameState gState;

//     public GameObject gameLabel;

//     Text gameText;

//     Main_PMove Player;

//     public GameObject gameOption;

//     if(Input.GetButtonDown("elsescape"))
//     {
//         public void OpenOtion()
//         {
//         gameOption.SetActive(true);
//         Time.timeScale = 0f;
//         gState = GameState.Pause;
//         }

//         public void closeOption()
//         {
//         gameOption.SetActive(false);
//         Time.timeScale = 1.0f;
//         gState = GameState.Run;
//         }
//     }
//     public void Restart()
//     {
//         Time.timeScale = 1.0f;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void QuitGame()
//     {
//         Application.Quit();
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         Player = GameObject.Find("Player").GetComponent<Main_PMove>();

//         gState = GameState.Ready;

//         gameText = gameLabel.GetComponent<Text>();

//         StartCoroutine(ReadytoStart());

//     }

//     IEnumerator ReadytoStart(){

//         yield return new WaitForSeconds(2f);

//         gameLabel.SetActive(false);

//         gState = GameState.Run;
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         if(Player.hp <= 0)
//         {
//             gameLabel.SetActive(true);
//             gameText.text = "GameOver";
            
//             gameText.color = new Color32(255,0,0,255);
//             gState = GameState.GameOver;
//         }
//     }
// }
