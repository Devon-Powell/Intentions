using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessData : MonoBehaviour
{
    [SerializeField] private GameObject BusinessGameObject;
    [SerializeField] private int businessId;
    [SerializeField] private string businessName;

    [SerializeField] private int maximumEmployees;
    [SerializeField] private int employeeWage;

    [SerializeField] private int openingHour;
    [SerializeField] private int closingHour;
}
