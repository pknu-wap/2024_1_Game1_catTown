using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PaperStatus : MonoBehaviour
{
    [SerializeField]
    private int ImageIndex;

    private bool isImageAppear = false;
    private bool isEnter = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isImageAppear && isEnter)
            {
                InteractionUI.Instance.imageAppear(ImageIndex - 1);
                InteractionUI.Instance.textDisappear();
                isImageAppear = true;
            }
            else
            {
                InteractionUI.Instance.imageDisAppear(ImageIndex - 1);
                InteractionUI.Instance.textAppear();
                isImageAppear = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractionUI.Instance.textAppear();
            isEnter = true;
        }

    }

    // FixedUpdate() -> 시간 간격으로 분할해서 돌아감. 
    // 키 입력같은 건 Update()
    // 물리적인 움직임이 FixedUpdate()
    // private void OnTriggerStay ( 사용 불가능 )

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractionUI.Instance.textDisappear();
            isEnter = false;
        }

    }
}
