using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �÷��̾� �̵� �ӵ�

    void Update()
    {
        // �Է� �� �ޱ�
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �̵� ���� ���
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // �̵� ó��
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
