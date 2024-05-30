using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToNextScene : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == player)
        {            
            Debug.Log("Switched the Scene ");
            SceneManager.LoadScene("constructionSite");
        }

    }
}
