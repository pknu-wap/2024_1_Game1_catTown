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

    // FixedUpdate() -> �ð� �������� �����ؼ� ���ư�. 
    // Ű �Է°��� �� Update()
    // �������� �������� FixedUpdate()
    // private void OnTriggerStay ( ��� �Ұ��� )

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractionUI.Instance.textDisappear();
            isEnter = false;
        }

    }
}
