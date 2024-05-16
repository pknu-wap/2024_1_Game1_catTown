using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnClick : MonoBehaviour
{
    public float interactionDistance = 3.0f; // �÷��̾�� ������Ʈ ������ �Ÿ�
    public Image imageToShow; // ������ �̹��� UI ������Ʈ

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (imageToShow != null)
        {
            imageToShow.gameObject.SetActive(false); // �ʱ⿡�� �̹����� ��Ȱ��ȭ
        }
    }

    void Update()
    {
        if (player == null || imageToShow == null)
            return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= interactionDistance)
        {
            if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
            {
                ShowImage();
            }
        }
    }

    void ShowImage()
    {
        imageToShow.gameObject.SetActive(true); // �̹����� Ȱ��ȭ
    }
}
