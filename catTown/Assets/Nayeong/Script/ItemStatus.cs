using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    public int healValue;

    private float rotationSpeed = 50f;
    private float bobSpeed = 1.5f;
    private float bobHeight = 0.3f;
    private float originalY;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        // ������ ȸ��
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // �� �Ʒ� ������
        float newY = originalY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
