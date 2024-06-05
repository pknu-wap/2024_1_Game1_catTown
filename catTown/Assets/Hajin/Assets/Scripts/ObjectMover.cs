using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    private bool isPlayerInTrigger = false;
    public int Force = -5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(Force, 0f, 0f, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInTrigger = false;
        }
    }
}