using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Information")]
    public string activityName;
    public string activityDescription;
    public Vector3 activityLocation;
    public Quaternion activityRotation;
    public Building building;
    

    [Header("Available Hours")] [Range(0, 23)]
    public float activityHourMin;
    [Range(0, 23)]
    public float activityHourMax;
    
    
    [Header("Time Spent")]
    [Range(0,1440)]
    public float activityDuration;
    [Range(-180,180)]
    public float durationRndMin;
    [Range(-180,180)]
    public float durationRndMax;
    
    [Header("NPC Stat Changes")]
    [Range(-100,100)]
    public float healthAffect;
    [Range(-100,100)]
    public float mentalHealthAffect;
    [Range(-100,100)]
    public float hungerAffect;
    [Range(-100,100)]
    public float energyAffect;
    [Range(-100,100)]
    public float moneyAffect;

    [Header("NPC Stat Modifiers")]
    public List<InteractableStatModifier> interactableStatModifiers;

    protected virtual void Awake()
    {
        building = (Building) transform.parent.parent.GetComponent(typeof(Building));
    }
    
    protected virtual void Start()
    {
        activityLocation = transform.position;
        activityRotation = transform.rotation;
    }
    
    
}
