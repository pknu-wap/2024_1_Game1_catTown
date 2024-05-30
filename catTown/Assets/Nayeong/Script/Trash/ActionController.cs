using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;

    [SerializeField]
    private Text actionText;

    void Update()
    {
        CheckPaper();
    }

    private void CheckPaper()
    {
        LayerMask layerMask = LayerMask.GetMask("Paper");
        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, range, layerMask))
        {
            actionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Show Paper Image");
            }
        }
        else
            actionText.gameObject.SetActive(false);
    }

}
