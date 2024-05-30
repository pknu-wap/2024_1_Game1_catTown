using UnityEngine;

public class WeightDetection : MonoBehaviour
{
    public float weightThreshold = 10f; 
    public GameObject objectToDestroy; 
    Animator anim;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); 
        if (rb != null)
        {
            float weight = rb.mass; 
            if (weight >= weightThreshold)
            {
                anim.SetTrigger("Open");
            }
        }
    }


}
