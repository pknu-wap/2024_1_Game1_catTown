using System.Collections;
using UnityEngine;

public class oepnCloset : MonoBehaviour
{
    int drawerCount = 0;
    bool isColliding = false; // 물체와 충돌 중인지 여부를 나타내는 변수
    public GameObject drawer;
    public Transform targetRotation; // 목표 회전
    public float rotationSpeed = 2f; // 회전 속도

    void Update()
    {
        // 물체와 충돌 중이고, E 키 입력이 감지되면 부드럽게 회전
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RotateDrawer());
        }
    }

    IEnumerator RotateDrawer()
    {
        Quaternion startingRotation = drawer.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            drawer.transform.rotation = Quaternion.Lerp(startingRotation, targetRotation.rotation, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed;
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
