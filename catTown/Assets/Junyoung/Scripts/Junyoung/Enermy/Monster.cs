using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget;
    private Main_PMove targetEntity;
    private NavMeshAgent navMeshAgent;
    private Animator monsterAnimator;
    private Transform monsterTransform;
    [SerializeField] Transform monsterRespawn;
    private Main_PMove player;
    private float attackTimer = 0f;

    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip stepSound;  // 발소리 AudioSource
    public float footstepInterval = 0.5f;    // 발소리 재생 간격
    public float initialDelay = 4.5f;        // 발소리 초기 딜레이

    private AudioSource audioSource;         // AudioSource 컴포넌트
    private float footstepTimer;
    private bool initialDelayPassed = false;

    public float baseSpeed = 3.0f;          // 기본 속도
    public float midSpeed = 5.0f;           // 중간 속도
    public float maxSpeed = 7.0f;           // 최대 속도
    public float speedChangeDistance1 = 15.0f; // 중간 속도 거리
    public float speedChangeDistance2 = 5.0f;  // 기본 속도 거리

    private string logFilePath;             // 로그 파일 경로
    private Vector3 lastPlayerPosition;     // 이전 플레이어 위치
    private Vector3 lastMonsterPosition;    // 이전 몬스터 위치
    private float playerSpeed;              // 현재 프레임의 플레이어 속도
    private float monsterSpeed;             // 현재 프레임의 몬스터 속도
    private float distanceToPlayer;         // 현재 몬스터와 플레이어 간 거리

    private bool hasTarget
    {
        get
        {
            return targetEntity != null;
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        monsterAnimator = GetComponent<Animator>();
        monsterTransform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        footstepTimer = initialDelay;

        // 중복 없는 파일 이름 생성
        logFilePath = GenerateUniqueFilePath("MonsterPlayerSpeedLog", "csv");

        // 로그 파일 초기화
        File.WriteAllText(logFilePath, "Time,PlayerSpeed,MonsterSpeed,DistanceToPlayer\n");
    }

    void Start()
    {
        lastPlayerPosition = Vector3.zero;
        lastMonsterPosition = monsterTransform.position;

        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        monsterAnimator.SetBool("HasTarget", hasTarget);
        attackTimer += Time.deltaTime;

        // 발소리 재생 타이머
        footstepTimer -= Time.deltaTime;
        if (footstepTimer <= 0 && hasTarget)
        {
            if (!initialDelayPassed)
            {
                initialDelayPassed = true;
                footstepTimer = footstepInterval; // 이후부터는 간격으로 설정
            }
            PlayStepSound();
            footstepTimer = footstepInterval;
        }

        // 거리 기반 속도 변경
        if (hasTarget)
        {
            UpdateSpeedBasedOnDistance();
        }

        // 속도 및 거리 계산, 로그 기록
        if (player != null)
        {
            CalculateSpeedsAndDistance();
            LogSpeedData(); // 각 프레임마다 로그 기록
        }
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            if (!hasTarget)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 8f, whatIsTarget);

                for (int i = 0; i < colliders.Length; i++)
                {
                    player = colliders[i].GetComponent<Main_PMove>();
                    if (player != null)
                    {
                        targetEntity = player;
                        lastPlayerPosition = player.transform.position; // 초기 위치 설정
                        break;
                    }
                }

                // 5초 뒤 추격 시작
                monsterTransform.position = monsterRespawn.position;
                yield return new WaitForSeconds(4.5f);
            }
            else
            {
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2.5f && attackTimer >= 3.0f && player.hp > 0)
                {
                    PlayAttackSound();
                    attackTimer = 0;
                    monsterAnimator.SetTrigger("Hit");

                    player.hp -= 2;
                    Debug.Log("attack");

                    Debug.Log("Player HP: " + player.hp);
                    if (player.hp <= 0)
                    {
                        Time.timeScale = 0f; // 게임 종료
                    }
                }
                else
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void UpdateSpeedBasedOnDistance()
    {
        distanceToPlayer = Vector3.Distance(transform.position, targetEntity.transform.position);

        if (distanceToPlayer > speedChangeDistance1)
        {
            // 먼 거리: 최대 속도
            navMeshAgent.speed = maxSpeed;
            footstepInterval = 0.35f;
        }
        else if (distanceToPlayer > speedChangeDistance2 && distanceToPlayer <= speedChangeDistance1)
        {
            // 중간 거리: 중간 속도
            navMeshAgent.speed = midSpeed;
            footstepInterval = 0.4f;
        }
        else if (distanceToPlayer <= speedChangeDistance2)
        {
            // 가까운 거리: 기본 속도
            navMeshAgent.speed = baseSpeed;
            footstepInterval = 0.5f;
        }
    }

    private void CalculateSpeedsAndDistance()
    {
        // 플레이어 속도 계산
        playerSpeed = Vector3.Distance(player.transform.position, lastPlayerPosition) / Time.deltaTime;
        lastPlayerPosition = player.transform.position;

        // 몬스터 속도 계산
        monsterSpeed = navMeshAgent.velocity.magnitude;
        lastMonsterPosition = monsterTransform.position;

        // 거리 계산
        distanceToPlayer = Vector3.Distance(monsterTransform.position, player.transform.position);
    }

    private void LogSpeedData()
    {
        // 시간(Time), 플레이어 속도(PlayerSpeed), 몬스터 속도(MonsterSpeed), 거리(DistanceToPlayer) 로그 저장
        string logEntry = $"{Time.time:F2},{playerSpeed:F2},{monsterSpeed:F2},{distanceToPlayer:F2}\n";
        File.AppendAllText(logFilePath, logEntry);

        // 디버그 출력
        Debug.Log($"Time: {Time.time:F2}, PlayerSpeed: {playerSpeed:F2}, MonsterSpeed: {monsterSpeed:F2}, DistanceToPlayer: {distanceToPlayer:F2}");
    }

    private string GenerateUniqueFilePath(string baseFileName, string extension)
    {
        int fileIndex = 0;
        string filePath;
        do
        {
            filePath = Application.dataPath + $"/{baseFileName}_{fileIndex}.{extension}";
            fileIndex++;
        } while (File.Exists(filePath));

        return filePath;
    }

    void PlayStepSound()
    {
        if (stepSound != null)
        {
            audioSource.PlayOneShot(stepSound);
        }
        else
        {
            Debug.Log("Footstep clip not assigned.");
        }
    }

    void PlayAttackSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
        else
        {
            Debug.Log("AttackSound clip not assigned.");
        }
    }
}
