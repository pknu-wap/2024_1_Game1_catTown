using System;
using System.Collections;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class Jody : MonoBehaviour
{
    public LayerMask whatIsTarget; // �� ��� ���̾�
    private NavMeshAgent navMeshAgent; // ��� ��� AI ������Ʈ
    private Animator amyAnimator; // �ִϸ����� ������Ʈ
    private Main_PMove targetEntity; // ���� ���
    private Transform JodyTransform;
    private Main_PMove player;
    private int currentPointIndex = 0;
    private bool surprised = true;
    [SerializeField] int noiseLevel = 0;
    [SerializeField] Transform wakeUpPoint;
    [SerializeField] Transform sleepPoint;
    public bool wakeUP = false;


    // ������ ������ ���� ��ġ�� �����ϸ� Jody�� �ῡ�� ���� ������ �޷����� ����.


    // ������ ����� �����ϴ��� �˷��ִ� ������Ƽ
    private bool hasTarget
    {
        get
        {
            // ������ ����� �����ϰ�, ����� ������� �ʾҴٸ� true
            if (targetEntity != null /*&& !targetEntity.dead)*/)
            {
                return true;
            }

            // �׷��� �ʴٸ� false
            return false;
        }
    }

    void UPing()
    {
        if(player.ct == 50)
        {
            wakeUP = true;
        }

    }

    private void Awake()
    {
        // �ʱ�ȭ
        navMeshAgent = GetComponent<NavMeshAgent>();
        amyAnimator = GetComponent<Animator>();
        JodyTransform = GetComponent<Transform>();
    }

    void Start()
    {
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        if (wakeUP)
        {
            Debug.Log("WakeUP");
            StartCoroutine(UpdatePath());
        }
    }

    void Update()
    {
        // ���� ����� ���� ���ο� ���� �ٸ� �ִϸ��̼� ���
        amyAnimator.SetBool("HasTarget", hasTarget);

    }

    // �ֱ������� ������ ����� ��ġ�� ã�� ��� ����
    private IEnumerator UpdatePath()
    {
        // ��� �ִ� ���� ���� ����
        while (true)
        {
            // ���� �߰����� ���� ���
            if (!hasTarget)
            {
                // �ֺ��� ���� �ִ��� Ȯ��
                Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, whatIsTarget);
                for (int i = 0; i < colliders.Length; i++)
                {
                    player = colliders[i].GetComponent<Main_PMove>();
                    if (player != null /*&& !player.dead*/)
                    {
                        targetEntity = player;
                        break;
                    }
                }
                Debug.Log("no");
            }
            else // ���� �߰��� ���
            {
                Debug.Log("surprised");
                // ���缭�� �߰� �ִϸ��̼� ���
                amyAnimator.SetBool("HasTarget", true);
                if (surprised)
                {
                    float navmMeshSpeed = navMeshAgent.speed;
                    navMeshAgent.speed = 0;
                    JodyTransform.position = sleepPoint.position;
                    yield return new WaitForSeconds(6.0f);
                    JodyTransform.rotation = Quaternion.Euler(0, 90f, 0);
                    yield return new WaitForSeconds(6.5f);
                    JodyTransform.rotation = Quaternion.Euler(0, 0, 0);
                    JodyTransform.position = wakeUpPoint.position;
                    yield return new WaitForSeconds(12.0f);
                    navMeshAgent.speed = navmMeshSpeed;
                    surprised = false;
                }
                // ������ �Ÿ��� Ȯ���Ͽ� ���� ���� ���� ������ ���� ����
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 100f)
                {
                    Debug.Log("running");
                    // ���� ���� �ִϸ��̼� ���
                    amyAnimator.SetBool("isRunning", true);
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                    // ���� ���� ���
                    if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2f)
                    {
                        // �÷��̾ ���� ���� ���� ������ ����
                        amyAnimator.SetTrigger("Attack");
                        Debug.Log("attck");
                        player.hp -= 2;

                        Debug.Log("Player HP: " + player.hp);
                        if (player.hp <= 0)
                        {
                            Time.timeScale = 0f;
                        }
                    }
                }
            }

            // 0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
    }
}
