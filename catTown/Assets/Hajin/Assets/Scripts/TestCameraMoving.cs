using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMoving : MonoBehaviour
{
    float moveSpeed = 5f;
    public float MouseSensitivity = 400f; // 마우스 민감도
    private float MouseX;
    private float MouseY;

     private void Rotate()
     {
        MouseX += Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
        MouseY -= Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime;
        MouseY = Mathf.Clamp(MouseY, -90f, 90f); // 최대, 최소 설정
       // MouseX = Mathf.Clamp(MouseX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(MouseY, MouseX, 0f); // 각 축 계산
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (moveDirection.magnitude >= 0.1f)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
       Rotate();
       Move();
    }
}
