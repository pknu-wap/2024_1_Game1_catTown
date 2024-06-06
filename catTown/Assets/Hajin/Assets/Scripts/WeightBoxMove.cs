using UnityEngine;

public class WeightBoxMove : MonoBehaviour
{
    public float forceAmount = 5.0f;
    private GameObject player;
    private Rigidbody rb;
    public bool isPlayerInTrigger = false;
    public bool isObjectHidden = false;
    public GameObject objectToHandle; // 플레이어가 주울 오브젝트

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb != null && rb.mass > 5)
        {
            if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
            {
                ApplyForce();
            }
        }
        else
        {
            if (!isObjectHidden && isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
            {
                HideObject();
            }
            else if (isObjectHidden && Input.GetKeyDown(KeyCode.F))
            {
                ShowObjectAtPlayerPosition();
            }
        }
    }

    private void HideObject()
    {
        if (objectToHandle != null)
        {
            // 플레이어 위치로 이동하는 대신 멀리 이동
            objectToHandle.transform.position = new Vector3(1000f, 1000f, 1000f);
            isObjectHidden = true;
        }
    }

    private void ShowObjectAtPlayerPosition()
    {
        if (player != null && objectToHandle != null)
        {
            objectToHandle.transform.position = player.transform.position;
            isObjectHidden = false;
        }
    }

    private void ApplyForce()
    {
        if (rb != null)
        {
            rb.AddForce(player.transform.forward * forceAmount, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

}
