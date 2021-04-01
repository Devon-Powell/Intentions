using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[System.Serializable]
public class NPCData : MonoBehaviour
{
    // Reference to Character's GameObject
    public GameObject go;
    // Reference to NavMeshAgent on GameObject
    public NavMeshAgent agent;
    // Reference to ThirdPersonCharacter on GameObject
    public ThirdPersonCharacter character;
    
    
    // Character Stats \\
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
    public int homeType; // Apartment, Single House, Double House, etc
    public int homeIdentifier;
}
