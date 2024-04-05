using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget; // 추적 대상 레이어

    private Player targetEntity; // 추적 대상
    private NavMeshAgent navMeshAgent; // 경로 계산 AI 에이전트

    //public ParticleSystem hitEffect; // 피격 시 재생할 파티클 효과
    //public AudioClip deathSound; // 사망 시 재생할 소리
    //public AudioClip hitSound; // 피격 시 재생할 소리

    private Animator monsterAnimator; // 애니메이터 컴포넌트
    private AudioSource monsterAudioPlayer; // 오디오 소스 컴포넌트
    private Renderer monsterRenderer; // 렌더러 컴포넌트

    public float damage = 20f; // 공격력
    public float timeBetAttack = 0.5f; // 공격 간격
    private float lastAttackTime; // 마지막 공격 시점
    

    // 추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget
    {
        get
        {
            // 추적할 대상이 존재하고, 대상이 사망하지 않았다면 true
            if (targetEntity != null && !targetEntity.dead)
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
        monsterAudioPlayer = GetComponent<AudioSource>();
        monsterRenderer = GetComponentInChildren<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
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
            if (hasTarget)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(
                    targetEntity.transform.position);
            }
            else
            {
                // 추적 대상없음
                navMeshAgent.isStopped = true;

                // 20유닛의 반지름을 가진 가상의 구를 그렸을 때 구와 겹치는 모든 콜라이더를 가져옴
                // 단, whatIsTarget 레이러르 가진 콜라이더만 가져오도록 필터링
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                // 모든 콜라이더를 순회하면서 살아 있는 LivingEntity찾기
                for (int i = 0; i < colliders.Length; i++)
                {
                    // 콜라이더로부터 LivingEntity 컴포넌트 가져오기
                    Player livingEntity = colliders[i].GetComponent<Player>();

                    // 컴포넌트가 존재하고 살아있다면
                    if (livingEntity != null && !livingEntity.dead)
                    {
                        targetEntity = livingEntity;

                        break;
                    }
                }
            }

            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(0.25f);
        }
    }
}


