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

    public void textAppear()
    {
        basicText.gameObject.SetActive(true);
    }
    public void textDisappear()
    {
        basicText.gameObject.SetActive(false);
    }
}
