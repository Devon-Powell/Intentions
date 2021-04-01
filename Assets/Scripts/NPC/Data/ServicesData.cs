using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesData : MonoBehaviour
{
    public string serviceOffered;
    public int serviceCost;

    public ServicesData(string serviceOffered)
    {
        this.serviceOffered = serviceOffered;
    }
}
