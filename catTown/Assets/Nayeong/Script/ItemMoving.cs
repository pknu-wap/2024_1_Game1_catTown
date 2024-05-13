using UnityEngine;

public class RotateAndBob : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobSpeed = 1.5f;
    public float bobHeight = 0.3f;

    private float originalY;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        // 아이템 회전
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // 위 아래 움직임
        float newY = originalY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 아이템 충돌");
            GameManager.Instance.IncreasePlayerHealth();
        }
    }
}
