using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;

    GameObject player;

    [SerializeField] private Text basicText;
    [SerializeField] private Image[] paper = new Image[8];
    [SerializeField] private Image[] ending = new Image[4];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        player = GameObject.Find("Player");
    }

    /// <summary>
    /// "[F]" appear
    ///  Object Collider detect (OnTriggerEnter)
    /// </summary>
    public void textAppear()
    {
        basicText.gameObject.SetActive(true);
    }

    /// <summary>
    /// "[F]" disappear
    /// Object Collider detect (OnTriggerExit)
    /// </summary>
    public void textDisappear()
    {
        basicText.gameObject.SetActive(false);
    }

    // paper image appear ( i : image index )
    public void imageAppear(int i)
    {
        paper[i].gameObject.SetActive(true);
    }

    // paper image disappear ( i : image index )
    public void imageDisAppear(int i)
    {
        paper[i].gameObject.SetActive(false);
    }

    // give Caution Amount to Player
    public void GiveCaution(int ct)
    {
        player.GetComponent<Main_PMove>().ct += ct;   
    }

    // appear ending credit ( i : image index )
    public void endingAppear(int i)
    {
        ending[i].gameObject.SetActive(true);
    }

    // disappear ending credit ( i : image index )
    public void endingDisAppear(int i)
    {
        ending[i].gameObject.SetActive(false);
    }

}
