using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public float rotateSpeed = 90f; 
    public GameObject craneObject; 
    public GameObject neckObject; 
    public float neckDownSpeed = 2f; 
    public float neckOffsetY = 1f; 

    public GameObject button1; // 회전 좌
    public GameObject button2; // 전진
    public GameObject button3; // 회전 우

    private bool is_Grabbing = false; // 물체 집기 여부
    private GameObject grabbedObject; // 잡고 있는 물체
    private Vector3 neckOriginalPosition; 
    private bool isNeckMoving = false; 

    void Start()
    {
        neckOriginalPosition = neckObject.transform.position; 
    }

    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (is_Grabbing)
            {
                ReleaseObject(); 
            }
            else
            {
                GrabObject(); 
            }
        }


        if (is_Grabbing && grabbedObject != null)
        {
            MoveGrabbedObject(); 
        }
    }

    public void HandleButtonClick(GameObject button)
    {
        if (button == button1)
        {
            RotateLeft();
        }
        else if (button == button2)
        {
            MoveForward();
        }
        else if (button == button3)
        {
            RotateRight();
        }
    }

    private void RotateLeft()
    {
        craneObject.transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
    }

    private void MoveForward()
    {
        craneObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void RotateRight()
    {
        craneObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void GrabObject()
    {
        is_Grabbing = true;
        isNeckMoving = true;
        RaycastHit hit;
        if (Physics.Raycast(neckObject.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.tag == "Grabbable")
            {
                grabbedObject = hit.collider.gameObject;
                grabbedObject.transform.SetParent(neckObject.transform);
                isNeckMoving = false;
                neckObject.transform.position = neckOriginalPosition;
            }
        }
    }

    private void ReleaseObject()
    {
        is_Grabbing = false;
        if (grabbedObject != null)
        {
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }
        isNeckMoving = false;
        neckObject.transform.position = neckOriginalPosition;
    }

    private void MoveGrabbedObject()
    {

        grabbedObject.transform.position = neckObject.transform.position + Vector3.up * neckOffsetY;
    }

    void LateUpdate()
    {
        if (isNeckMoving)
        {
            MoveNeckDown();
        }
    }

    private void MoveNeckDown()
    {
        neckObject.transform.position = Vector3.MoveTowards(neckObject.transform.position, neckOriginalPosition + Vector3.down * 10f, neckDownSpeed * Time.deltaTime);


        if (Vector3.Distance(neckObject.transform.position, neckOriginalPosition + Vector3.down * 10f) < 0.01f)
        {
            isNeckMoving = false;
            neckObject.transform.position = neckOriginalPosition;
        }
    }
}