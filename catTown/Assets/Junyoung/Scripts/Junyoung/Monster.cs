using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget; // 추적 대상 레이어
    private Main_PMove targetEntity; // 추적 대상
    private NavMeshAgent navMeshAgent; // 경로 계산 AI 에이전트
    private Animator monsterAnimator; // 애니메이터 컴포넌트
    private bool isAttacking = false; // 공격 중인지 여부

    public AudioClip footstepSound; // 발 소리 오디오 클립
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    // 추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget
    {
        get
        {
            // 추적할 대상이 존재하고, 대상이 사망하지 않았다면 true
            if (targetEntity != null)// && !targetEntity.dead)
            {
                return true;
            }

            // 그렇지 않다면 false
            return false;
        }
    }

    private void Awake()
    {
        // 초기화
        navMeshAgent = GetComponent<NavMeshAgent>();
        monsterAnimator = GetComponent<Animator>();
        // 오디오 소스 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
        // 발 소리 오디오 클립 설정
        //audioSource.clip = footstepSound;
        
    }

    void Start()
    {
        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        // 추적 대상의 존재 여부에 따라 다른 애니메이션 재생
        monsterAnimator.SetBool("HasTarget", hasTarget);
    }

    // 주기적으로 추적할 대상의 위치를 찾아 경로 갱신
    private IEnumerator UpdatePath()
    {
        // 살아 있는 동안 무한 루프
        while (true)
        {
            if (!hasTarget)
            {
                // 추적 대상이 없을 때 코드
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                // 주변에 플레이어가 있는지 확인
                for (int i = 0; i < colliders.Length; i++)
                {
                    Main_PMove player = colliders[i].GetComponent<Main_PMove>();
                    if (player != null) //&& !player.dead)
                    {
                        targetEntity = player;
                        break;
                    }
                }
            }
            else
            {
                // 추적 중인 경우
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2f && !isAttacking)
                {
                    // 플레이어가 일정 범위 내에 있으면 공격
                    monsterAnimator.SetBool("isHit", true);
                }
                else
                {
                    // 일정 범위 내에 플레이어가 없으면 공격을 멈추고 다시 추격
                    monsterAnimator.SetBool("isHit", false);
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetEntity.transform.position);
              
                }
            }

            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(0.25f);
        }
    }

    // 오디오를 재생하는 함수
    void PlayAudio()
    {
        // 오디오 재생
        audioSource.Play();
    }
}
