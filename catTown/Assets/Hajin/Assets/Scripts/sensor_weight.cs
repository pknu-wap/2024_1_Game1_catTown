using UnityEngine;

public class WeightDetection : MonoBehaviour
{
    public float weightThreshold = 10f; 
    public GameObject objectToDestroy; 
    public float weight;
    Animator anim;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        anim = objectToDestroy.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); 
        if (rb != null)
        {
            weight = rb.mass; 
            
            if (weight >= weightThreshold)
            {
                anim.SetTrigger("Open");
            }
        }
    }


}
