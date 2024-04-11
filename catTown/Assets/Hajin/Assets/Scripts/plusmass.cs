using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private float otherMass;

    private void OnCollisionEnter(Collision collision)
    {
        //컴포넌트 가져오기
        Rigidbody otherRigidbody = collision.collider.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            
            otherMass = otherRigidbody.mass;
            
         
            Debug.Log("충돌한 오브젝트의 질량: " + otherMass);

            Rigidbody ownRigidbody = GetComponent<Rigidbody>();
            if (ownRigidbody != null)
            {
                ownRigidbody.mass += otherMass;
                Debug.Log("현재 오브젝트의 총 질량: " + ownRigidbody.mass);
            }
        }
    }
}
