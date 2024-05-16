using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 플레이어 이동 속도

    void Update()
    {
        // 입력 값 받기
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 이동 벡터 계산
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 이동 처리
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
