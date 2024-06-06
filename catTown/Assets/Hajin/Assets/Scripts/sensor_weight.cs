using UnityEngine;

public class WeightDetection : MonoBehaviour
{
<<<<<<< HEAD
    public float weightThreshold = 10f;
    public GameObject objectToDestroy;
    public float totalWeight; // 전체 무게 저장할 변수 추가
    
    Animator anim;

=======
    public float weightThreshold = 10f; 
    public GameObject objectToDestroy; 
    public float weight;
    Animator anim;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
>>>>>>> develop
    void Start()
    {
        anim = objectToDestroy.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
<<<<<<< HEAD
            totalWeight += rb.mass; // 전체 무게에 충돌한 오브젝트 무게 추가
            if (totalWeight >= weightThreshold)
=======
            weight = rb.mass; 
            
            if (weight >= weightThreshold)
>>>>>>> develop
            {
                anim.SetTrigger("Open");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            totalWeight -= rb.mass; // 충돌 해제 시 전체 무게에서 제거
        }
    }
}