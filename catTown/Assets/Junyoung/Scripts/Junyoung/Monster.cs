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
    private Main_PMove player;
    private float attactTimer = 0f;

    public AudioClip footstepSound; // �� �Ҹ� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ
    [SerializeField] Transform monsterRespawn;

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
        audioSource = GetComponent<AudioSource>();
        monsterTransform = GetComponent<Transform>();
        // �� �Ҹ� ����� Ŭ�� ����
        //audioSource.clip = footstepSound;
        
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
                    
                    attactTimer = 0;
                    monsterAnimator.SetBool("isHit", true);
                    isHitting = true;
                    player.hp -= 2;
                    Debug.Log("attack");
                    
                    Debug.Log("Player HP: " + player.hp);
                    if(player.hp <= 0)
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

    // ������� ����ϴ� �Լ�
    void PlayAudio()
    {
        // ����� ���
        audioSource.Play();
    }
    public void Respawn()
    {
        monsterTransform.position = monsterRespawn.position;
    }
}
