using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[System.Serializable]
public class NPCData : MonoBehaviour
{
    public GameObject npcGameObject;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    
    // Maintenance Stats
    public float currentHealth;
    public float currentMentalHealth;
    public float currentHunger;
    public float currentEnergy;
    public float currentMoney;

    // Personal Stats
    public float minimumMovementSpeed;
    public float maximumMovementSpeed;
    
    
    // Personal data
    public bool isMale;
    public bool isMarried;

    public string firstName;
    public string lastName;

    public int age;
    public int birthday;

    
    // Employment data
    public bool isEmployed;
    public string workplace;
    public int workplaceIdentifier;

    
    // Household data
    public bool hasHome;
    public int homeType;
    public int homeIdentifier;
    
    private void Start()
    {
        //NPCDataGenerator.AssignCharacterData(this);
    }
}