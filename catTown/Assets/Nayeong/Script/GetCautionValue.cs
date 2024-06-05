using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCautionValue : MonoBehaviour
{
    [SerializeField]
    private int cautionAmount = 5;

    public int CautionAmount => cautionAmount;

}
