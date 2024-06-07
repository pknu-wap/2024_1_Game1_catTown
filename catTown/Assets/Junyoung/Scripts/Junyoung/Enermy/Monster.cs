using System.Collections;
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
    private float attactTimer = 0f;

    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip stepSound;  // 발소리 AudioSource
    public float footstepInterval = 0.5f;    // 발소리 재생 간격
    public float initialDelay = 4.5f;        // 발소리 초기 딜레이

    private AudioSource audioSource;         // AudioSource 컴포넌트
    private float footstepTimer;
    private bool initialDelayPassed = false;
    public bool speedUp = false;

    private bool hasTarget
    {
        get
        {
            if (targetEntity != null)
            {
                return true;
            }
            return false;
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
    }

    void Start()
    {
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        monsterAnimator.SetBool("HasTarget", hasTarget);
        attactTimer += Time.deltaTime;
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
        if(speedUp)
        {
            SpeedUP();
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
                        break;
                    }
                }
                // 5초뒤 추격
                monsterTransform.position = monsterRespawn.position;
                yield return new WaitForSeconds(4.5f);
            }
            else
            {
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2.5f && attactTimer >= 3.0f && player.hp > 0)
                {
                    PlayAttackSound();
                    attactTimer = 0;
                    monsterAnimator.SetTrigger("Hit");
                   
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
                    
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                }

            }
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


