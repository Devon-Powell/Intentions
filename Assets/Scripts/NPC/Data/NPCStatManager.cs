using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatManager : MonoBehaviour
{
    public NPCData npcData;

    public float hungerModifier;
    public float energyModifier;
    private int sluggishnessStartLevel;

    private void Start()
    {
        npcData = GetComponent<NPCData>();
        hungerModifier = -0.1f;
        energyModifier = -0.1f;
        sluggishnessStartLevel = 33;
    }
    
    private void Update()
    {
        AdjustHunger(hungerModifier * Time.deltaTime);
        AdjustFatigue(energyModifier * Time.deltaTime);
    }

    private void AdjustHealth(float amount)
    {
        npcData.currentHealth += amount;

        if (npcData.currentMentalHealth > 100) npcData.currentMentalHealth = 100;

        if (npcData.currentHealth <= 0)
        {
            // Kill NPC
        }
    }
    
    private void AdjustMentalHealth(float amount)
    {
        npcData.currentMentalHealth += amount;
        
        if (npcData.currentMentalHealth > 100) npcData.currentMentalHealth = 100;
        
    }
    
    private void AdjustHunger(float amount)
    {
        npcData.currentHunger += amount;

        if (npcData.currentHunger > 100) npcData.currentHunger = 100;
        
        if (npcData.currentHunger <= 0) npcData.currentHealth += amount;
    }
    
    private void AdjustFatigue(float amount)
    {
        npcData.currentEnergy += amount;

        if (npcData.currentEnergy > 0 && npcData.currentEnergy <= sluggishnessStartLevel)
        {
            npcData.minimumMovementSpeed /= 2;
            npcData.maximumMovementSpeed /= 2;
            
            // Sluggish Movement
        }

        if (npcData.currentEnergy <= 0)
        {
            
        }
    }
    
    private void AdjustMoney(float amount)
    {
        npcData.currentMoney += amount;
    }
}
