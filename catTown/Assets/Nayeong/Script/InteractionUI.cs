using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;

    [SerializeField] private Text basicText;
    [SerializeField] private Image[] paper = new Image[8];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// "[Q]" appear
    ///  Object Collider detect (OnTriggerEnter)
    /// </summary>
    public void textAppear()
    {
        basicText.gameObject.SetActive(true);
    }

    /// <summary>
    /// "[Q]" disappear
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
}
