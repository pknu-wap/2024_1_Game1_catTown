using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Jody : MonoBehaviour
{
    public LayerMask whatIsTarget;
    private NavMeshAgent navMeshAgent;
    private Animator JodyAnimator;
    private Main_PMove targetEntity;
    private Transform JodyTransform;
    private Main_PMove player;
    private int currentPointIndex = 0;
    private bool surprised = true;
    [SerializeField] int noiseLevel = 0;
    [SerializeField] Transform wakeUpPoint;
    [SerializeField] Transform sleepPoint;
    public bool wakeUP = false;

    private bool isCoroutineRunning = false;

    private bool hasTarget
    {
        get
        {
            return targetEntity != null;
        }
    }

    void UPing()
    {

        if (player.ct == 50)
        {
            wakeUP = true;
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        JodyAnimator = GetComponent<Animator>();
        JodyTransform = GetComponent<Transform>();
    }

    void Start()
    {

    }

    void Update()
    {
        JodyAnimator.SetBool("HasTarget", hasTarget);

        if (!isCoroutineRunning && (CheckPlayerDistance(1f) || wakeUP))
        {
            isCoroutineRunning = true;
            StartCoroutine(UpdatePath());
        }
    }

    private bool CheckPlayerDistance(float distance)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, whatIsTarget);
        for (int i = 0; i < colliders.Length; i++)
        {
            player = colliders[i].GetComponent<Main_PMove>();
            if (player != null)
            {
                targetEntity = player;
                return true;
            }
        }
        return false;
    }

    private IEnumerator UpdatePath()
    {
        isCoroutineRunning = true;

        while (true)
        {
            if (!hasTarget)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, whatIsTarget);
                for (int i = 0; i < colliders.Length; i++)
                {
                    player = colliders[i].GetComponent<Main_PMove>();
                    if (player != null)
                    {
                        targetEntity = player;
                        break;
                    }
                }
                Debug.Log("no");
            }
            else
            {
                Debug.Log("surprised");

                JodyAnimator.SetBool("HasTarget", true);
                if (surprised)
                {
                    float navMeshSpeed = navMeshAgent.speed;
                    navMeshAgent.speed = 0;
                    navMeshAgent.enabled = false; // NavMeshAgent 비활성화
                    JodyTransform.position = sleepPoint.position;
                    yield return new WaitForSeconds(4.25f);
                    JodyTransform.rotation = Quaternion.Euler(0, 90f, 0);
                    JodyAnimator.SetTrigger("LookAround");
                    Debug.Log("rotate");
                    yield return new WaitForSeconds(6.0f);
                    JodyAnimator.SetTrigger("Surprised");
                    JodyTransform.rotation = Quaternion.Euler(0, 0, 0);
                    JodyTransform.position = wakeUpPoint.position;
                    Debug.Log("move position");
                    yield return new WaitForSeconds(8.0f);
                    navMeshAgent.enabled = true; // NavMeshAgent 다시 활성화
                    navMeshAgent.speed = navMeshSpeed;
                    surprised = false;
                }


                if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 100f && !surprised)
                {
                    Debug.Log("running");
                    JodyAnimator.SetBool("isRunning", true);
                    navMeshAgent.SetDestination(targetEntity.transform.position);
                    if (Vector3.Distance(transform.position, targetEntity.transform.position) <= 2f)
                    {
                        JodyAnimator.SetTrigger("Attack");
                        Debug.Log("attck");
                        yield return new WaitForSeconds(1.25f);
                        player.hp -= 10;

                        Debug.Log("Player HP: " + player.hp);
                        if (player.hp <= 0)
                        {
                            Time.timeScale = 0f;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
