using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    int drawerCount = 0;
    bool isColliding = false; // 물체와 충돌 중인지 여부를 나타내는 변수
    public GameObject drawer;
    public Transform targetPosition; // 목표 위치
    public float moveSpeed = 2f; // 이동 속도

    void Update()
    {
        // 물체와 충돌 중이고, E 키 입력이 감지되면 부드럽게 이동
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveDrawer());
        }
    }

    IEnumerator MoveDrawer()
    {
        Vector3 startingPosition = drawer.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            drawer.transform.position = Vector3.Lerp(startingPosition, targetPosition.position, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
        
        // drawerCount 증가
        drawerCount++;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 물체와 충돌한 경우 isColliding을 true로 설정
        if (collision.collider.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 물체와 충돌이 종료된 경우 isColliding을 false로 설정
        if (collision.collider.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
