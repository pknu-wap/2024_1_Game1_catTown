using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    [SerializeField] private int healAmount;
    public int HealAmount => healAmount;

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
        // set bobSpeed
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // set bobHeight
        float newY = originalY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
