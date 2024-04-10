using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public LayerMask whatIsTarget; // ���� ��� ���̾�
    private Player targetEntity; // ���� ���
    private NavMeshAgent navMeshAgent; // ��� ��� AI ������Ʈ
    private Animator monsterAnimator; // �ִϸ����� ������Ʈ
    private bool isAttacking = false; // ���� ������ ����

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
                    Player player = colliders[i].GetComponent<Player>();
                    if (player != null && !player.dead)
                    {
                        targetEntity = player;
                        break;
                    }
                }
            }
            else
            {
                // ���� ���� ���
                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 5f && !isAttacking)
                {
                    // �÷��̾ ���� ���� ���� ������ ����
                    monsterAnimator.SetTrigger("Hit");
                }
                else
                {
                    // ���� ���� ���� �÷��̾ ������ ���� ���
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                }
            }

            // 0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
    }
}
