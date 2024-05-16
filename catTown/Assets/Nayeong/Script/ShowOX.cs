using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnClick : MonoBehaviour
{
    public float interactionDistance = 3.0f; // 플레이어와 오브젝트 사이의 거리
    public Image imageToShow; // 보여줄 이미지 UI 컴포넌트

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (imageToShow != null)
        {
            imageToShow.gameObject.SetActive(false); // 초기에는 이미지를 비활성화
        }
    }

    void Update()
    {
        if (player == null || imageToShow == null)
            return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= interactionDistance)
        {
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
            {
                ShowImage();
            }
        }
    }

    void ShowImage()
    {
        imageToShow.gameObject.SetActive(true); // 이미지를 활성화
    }
}
