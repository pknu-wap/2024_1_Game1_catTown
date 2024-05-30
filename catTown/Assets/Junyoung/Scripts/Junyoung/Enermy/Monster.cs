using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget; // ���� ��� ���̾�
    private Main_PMove targetEntity; // ���� ���
    private NavMeshAgent navMeshAgent; // ��� ��� AI ������Ʈ
    private Animator monsterAnimator; // �ִϸ����� ������Ʈ
    private bool isAttacking = false; // ���� ������ ����
    public bool isHitting = false;
    private Transform monsterTransform;
    [SerializeField] Transform monsterRespawn;
    private Main_PMove player;
    private float attactTimer = 0f;

    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip stepSound;  // 발소리 AudioSource
    public float footstepInterval = 0.5f;    // 발소리 재생 간격
    public float initialDelay = 4.5f;        // 발소리 초기 딜레이

    private AudioSource audioSource;         // AudioSource 컴포넌트
    private float footstepTimer;
    private bool initialDelayPassed = false;
    public bool speedUp = false;


    // ������ ����� �����ϴ��� �˷��ִ� ������Ƽ
    private bool hasTarget
    {
        get
        {
            // ������ ����� �����ϰ�, ����� ������� �ʾҴٸ� true
            if (targetEntity != null)// && !targetEntity.dead)
            {
                return true;
            }

            // �׷��� �ʴٸ� false
            return false;
        }
    }

    private void Awake()
    {
        // �ʱ�ȭ
        navMeshAgent = GetComponent<NavMeshAgent>();
        monsterAnimator = GetComponent<Animator>();
        // ����� �ҽ� ������Ʈ ��������
        monsterTransform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        footstepTimer = initialDelay;
    }

    void Start()
    {
        
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        // ���� ����� ���� ���ο� ���� �ٸ� �ִϸ��̼� ���
        monsterAnimator.SetBool("HasTarget", hasTarget);
        attactTimer += Time.deltaTime;
        // 발소리 재생 타이머
        footstepTimer -= Time.deltaTime;
        if (footstepTimer <= 0)
        {
            if (!initialDelayPassed)
            {
                initialDelayPassed = true;
                footstepTimer = footstepInterval; // 이후부터는 간격으로 설정
            }
            PlayStepSound();
            footstepTimer = footstepInterval;
        }
        if(speedUp)
        {
            SpeedUP();
        }    
    }

    // �ֱ������� ������ ����� ��ġ�� ã�� ��� ����
    private IEnumerator UpdatePath()
    {
        // ��� �ִ� ���� ���� ����
        while (true)
        {
            if (!hasTarget)
            {
                // ���� ����� ���� �� �ڵ�
                Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, whatIsTarget);

                // �ֺ��� �÷��̾ �ִ��� Ȯ��
                for (int i = 0; i < colliders.Length; i++)
                {
                    player = colliders[i].GetComponent<Main_PMove>();
                    if (player != null) //&& !player.dead)
                    {
                        targetEntity = player;
                        break;
                    }
                }
                // 5초뒤 추격
                monsterTransform.position = monsterRespawn.position;
                yield return new WaitForSeconds(4.5f);
            }
            else
            {
                // ���� ���� ���
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2.5f && !isAttacking && attactTimer >= 3.0f && player.hp > 0)
                {
                    // �÷��̾ ���� ���� ���� ������ ����
                    PlayAttackSound();
                    attactTimer = 0;
                    monsterAnimator.SetBool("isHit", true);
                    isHitting = true;
                    player.hp -= 2;
                    Debug.Log("attack");

                    Debug.Log("Player HP: " + player.hp);
                    if (player.hp <= 0)
                    {
                        Time.timeScale = 0f;
                    }
                }
                else
                {
                    // ���� ���� ���� �÷��̾ ������ ������ ���߰� �ٽ� �߰�
                    monsterAnimator.SetBool("isHit", false);
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                    isHitting = false;
                }

            }

            // 0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
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
        if (stepSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
        else
        {
            Debug.Log("AttakSound clip not assigned.");
        }
    }

    public void SpeedUP()
    {
        navMeshAgent.speed = 2.25f;
        footstepInterval = 0.35f;
        Debug.Log("speedUP");
    }
}


