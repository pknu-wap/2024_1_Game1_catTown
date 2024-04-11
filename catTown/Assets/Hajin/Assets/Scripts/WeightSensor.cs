using UnityEngine;

public class WeightSensor : MonoBehaviour
{
    public float weightThreshold = 10f; 
    public GameObject objectToDestroy; 

    private Rigidbody detectedRigidbody; 
    private float lastKnownMass = 0f; // 마지막으로 감지된 오브젝트의 질량

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && (detectedRigidbody == null || detectedRigidbody != rb)) 
        {
            detectedRigidbody = rb; // 감지된 오브젝트 업데이트
            UpdateDetectedObjectMass(); // 감지된 오브젝트의 질량 업데이트
            CheckThreshold(); 
        }
    }

    private void FixedUpdate()
    {
        if (detectedRigidbody != null)
        {
            // 오브젝트의 질량이 변경되었는지 확인
            if (detectedRigidbody.mass != lastKnownMass)
            {
                UpdateDetectedObjectMass(); // 감지된 오브젝트의 질량 업데이트
                CheckThreshold(); // 임계값을 초과하는지 확인
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && rb == detectedRigidbody) 
        {
            detectedRigidbody = null; // 초기화
        }
    }

    private void UpdateDetectedObjectMass()
    {
        lastKnownMass = detectedRigidbody.mass; // 감지된 오브젝트의 질량을 업데이트
        Debug.Log("감지된 질량 : " + lastKnownMass); 
    }

    private void CheckThreshold()
    {
        if (lastKnownMass >= weightThreshold)
        {
            Debug.Log("임계 초과"); 
            Destroy(objectToDestroy); 
        }
    }
}
