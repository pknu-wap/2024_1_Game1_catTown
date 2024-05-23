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
    public bool isHitting; //공격 모션 딜레이
    private float attackTimer = 0f;
    private Main_PMove player;

    public AudioClip footstepSound; // �� �Ҹ� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

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
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

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
            }
            else
            {
                // ���� ���� ���
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2f && !isAttacking)
                {
                   
                    // �÷��̾ ���� ���� ���� ������ ����
                    monsterAnimator.SetBool("isHit", true);

                    
                     
                    // if(attackTimer>5.0f)
                    // {
                    
                    // monsterAnimator.SetBool("isHit", false);
                    // attackTimer += Time.deltaTime;
                    // player.hp -= 2;
                    // Debug.Log(player.hp);

                    // }
                    // else
                    // {
                    //     attackTimer = 0f;
                    // }
                
                    // isHitting = true; 
                                
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

}
