using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget; // ���� ��� ���̾�

    private Player targetEntity; // ���� ���
    private NavMeshAgent navMeshAgent; // ��� ��� AI ������Ʈ

    //public ParticleSystem hitEffect; // �ǰ� �� ����� ��ƼŬ ȿ��
    //public AudioClip deathSound; // ��� �� ����� �Ҹ�
    //public AudioClip hitSound; // �ǰ� �� ����� �Ҹ�

    private Animator monsterAnimator; // �ִϸ����� ������Ʈ
    private AudioSource monsterAudioPlayer; // ����� �ҽ� ������Ʈ
    private Renderer monsterRenderer; // ������ ������Ʈ

    public float damage = 20f; // ���ݷ�
    public float timeBetAttack = 0.5f; // ���� ����
    private float lastAttackTime; // ������ ���� ����
    

    // ������ ����� �����ϴ��� �˷��ִ� ������Ƽ
    private bool hasTarget
    {
        get
        {
            // ������ ����� �����ϰ�, ����� ������� �ʾҴٸ� true
            if (targetEntity != null && !targetEntity.dead)
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
        monsterAudioPlayer = GetComponent<AudioSource>();
        monsterRenderer = GetComponentInChildren<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
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
            if (hasTarget)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(
                    targetEntity.transform.position);
            }
            else
            {
                // ���� ������
                navMeshAgent.isStopped = true;

                // 20������ �������� ���� ������ ���� �׷��� �� ���� ��ġ�� ��� �ݶ��̴��� ������
                // ��, whatIsTarget ���̷��� ���� �ݶ��̴��� ���������� ���͸�
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                // ��� �ݶ��̴��� ��ȸ�ϸ鼭 ��� �ִ� LivingEntityã��
                for (int i = 0; i < colliders.Length; i++)
                {
                    // �ݶ��̴��κ��� LivingEntity ������Ʈ ��������
                    Player livingEntity = colliders[i].GetComponent<Player>();

                    // ������Ʈ�� �����ϰ� ����ִٸ�
                    if (livingEntity != null && !livingEntity.dead)
                    {
                        targetEntity = livingEntity;

                        break;
                    }
                }
            }

            // 0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
    }
}


