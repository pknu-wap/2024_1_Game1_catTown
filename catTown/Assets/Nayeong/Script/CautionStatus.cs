using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class CautionStatus : MonoBehaviour
{
    private bool isCollidedWithPlayer = false;

    private int collidedCount = 0;

    private bool isBroken = false;

    [SerializeField]
    private int brokenCautionAmount = 20;
    public int BrokenCautionAmount => brokenCautionAmount;

    [SerializeField]
    private int fractionsCautionAmount = 2;
    public int FractionsCautionAmount => fractionsCautionAmount;

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
        if (!isBroken)
        {
            collidedCount++;
            if (collidedCount == 5)
            {
                // Broken Time delay ( to enable MeshCollider )
                StartCoroutine("OnBroken");
                InteractionUI.Instance.GiveCaution(BrokenCautionAmount);
                Debug.Log("OnBroken");
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

    IEnumerator OnBroken()
    {
        isBroken = true;

        breakableObject.gameObject.SetActive(false);

        // Need to add code : increase cautionAmount when broken
        //player.GetComponent<Main_PMove>().ct += brokenCautionAmount;
        cautionObject.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        breakableMeshCollider.enabled = false;
    }
}

