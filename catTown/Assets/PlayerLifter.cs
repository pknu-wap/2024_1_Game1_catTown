using UnityEngine;

public class PlayerLifter : MonoBehaviour
{
    public float liftForce = 10f; // 위로 올리는 힘의 크기
    public float liftDuration = 1f; // 위로 올리는 시간 (초)

    private bool isPlayerInTrigger = false;
    private Rigidbody playerRigidbody;
    private bool isLifting = false;
    private float liftTimer = 0f;

    private void Start()
    {
        // 플레이어 오브젝트의 Rigidbody 컴포넌트 가져오기
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 플레이어가 트리거 박스 안에 있고 F키를 눌렀을 때
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            isLifting = true; // 위로 올리기 시작
        }

        // 위로 올리는 중일 때
        if (isLifting)
        {
            LiftPlayer();
        }
    }

    private void LiftPlayer()
    {
        // 위로 올리는 힘 적용
        playerRigidbody.AddForce(Vector3.up * liftForce, ForceMode.Force);

        // 타이머 증가
        liftTimer += Time.deltaTime;

        // 일정 시간이 지나면 위로 올리기 중지
        if (liftTimer >= liftDuration)
        {
            isLifting = false;
            liftTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 트리거 박스에 들어왔을 때
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 트리거 박스에서 나갔을 때
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}