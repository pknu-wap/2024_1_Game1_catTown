using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public float rotateSpeed = 90f; 
    public GameObject craneObject; 
    public GameObject neckObject; 

    public GameObject button1; // 회전 좌
    public GameObject button2; // 전진
    public GameObject button3; // 회전 우

    private Vector3 neckOriginalPosition; 


    private Vector3 targetPosition; // 목표 위치
    private Quaternion targetRotation; // 목표 회전

    private bool isMoving = false; // 이동 여부
    private bool isRotating = false; // 회전 여부

    private GameObject player; // 플레이어

    void Start()
    {
        neckOriginalPosition = neckObject.transform.position; 
        targetPosition = craneObject.transform.position;
        targetRotation = craneObject.transform.rotation;

        player = GameObject.FindWithTag("Player"); // 플레이어를 찾습니다.
    }

    void Update()
    {
        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == button1)
                {
                    HandleButtonClick(button1);
                }
                else if (hit.collider.gameObject == button2)
                {
                    HandleButtonClick(button2);
                }
                else if (hit.collider.gameObject == button3)
                {
                    HandleButtonClick(button3);
                }
            }
        }



        // 부드럽게 이동 및 회전
        if (isMoving)
        {
            craneObject.transform.position = Vector3.MoveTowards(craneObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(craneObject.transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }

        if (isRotating)
        {
            craneObject.transform.rotation = Quaternion.RotateTowards(craneObject.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            if (Quaternion.Angle(craneObject.transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }
    }


    public void HandleButtonClick(GameObject button)
    {
        if (button == button1)
        {
            Debug.Log("Button 1 clicked");
            RotateLeft();
        }
        else if (button == button2)
        {
            Debug.Log("Button 2 clicked");
            MoveForward();
        }
        else if (button == button3)
        {
            Debug.Log("Button 3 clicked");
            RotateRight();
        }
    }

    private void RotateLeft()
    {
        targetRotation *= Quaternion.Euler(0, -rotateSpeed, 0);
        isRotating = true;
    }

    private void MoveForward()
    {
        targetPosition += craneObject.transform.forward * -moveSpeed;
        isMoving = true;
    }

    private void RotateRight()
    {
        targetRotation *= Quaternion.Euler(0, rotateSpeed, 0);
        isRotating = true;
    }

   
}

