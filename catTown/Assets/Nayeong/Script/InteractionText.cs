using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public static InteractionText Instance;

    [SerializeField] private Text basicText;

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
}
