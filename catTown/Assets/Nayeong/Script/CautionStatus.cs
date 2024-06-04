using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class CautionStatus : MonoBehaviour
{ 

    private bool isCollidedWithPlayer = false;

    private int collidedCount = 0;
    private bool isbroken = false;

    [SerializeField]
    private int brokenCautionAmount = 20;
    public int BrokenCautionAmount => brokenCautionAmount;

    private Transform breakableObject = null;
    private Transform cautionObject = null;

    GameObject player;

    private MeshCollider breakableMeshCollider = null;

    void Awake()
    {
        player = GameObject.Find("Player");
        breakableMeshCollider = GetComponent<MeshCollider>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "breakable")
            {
                breakableObject = transform.GetChild(i);
            }
            else
            {
                cautionObject = transform.GetChild(i);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // need to fix Collision of Caution Object
        if (!isbroken)
        {
            collidedCount++;
            if (collidedCount == 5)
            {
                // Broken Time delay ( to enable MeshCollider )
                StartCoroutine("Broken");
            }
        }

        /*if (!isbroken)
        {
            Debug.Log(breakableObject.name);
        }
        else
        {
            Debug.Log(cautionObject.name);
        }*/

        if (collision.transform.tag == "Player")
        {
            isCollidedWithPlayer = true;

        }
        else if (collision.transform.tag != "Monster")
        {
            isCollidedWithPlayer = false;
        }
    }

    IEnumerator Broken()
    {
        isbroken = true;

        breakableObject.gameObject.SetActive(false);

        // Need to add code : increase cautionAmount when broken
        //player.GetComponent<Main_PMove>().ct += brokenCautionAmount;
        Debug.Log(brokenCautionAmount);
        cautionObject.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        breakableMeshCollider.enabled = false;
    }
}

