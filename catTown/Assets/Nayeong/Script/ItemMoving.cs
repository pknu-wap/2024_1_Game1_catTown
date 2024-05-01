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
        // y축 주위로 회전시키기
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // 약간 위아래로 움직이기
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
