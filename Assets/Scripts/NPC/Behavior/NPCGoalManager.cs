using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NPCGoalManager : MonoBehaviour
{
    private static NPCLocationsSO _npcLocationsSo;
    public static NPCGoalManager instance;

    private void Start()
    {
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        instance = this;
    }

    public void FindPriority(NPCData npcData)
    {
        List<float> currentStats = new List<float>();
        currentStats.AddRange(new List<float>
        {
            npcData.currentHealth, npcData.currentMentalHealth, npcData.currentHunger, npcData.currentEnergy
        });

        int minimumStatIndex = currentStats.IndexOf(currentStats.Min());
        GoalSwitch(minimumStatIndex, npcData);
    }

    private void GoalSwitch(int index, NPCData npcData)
    {
        switch (index)
        {
            case 1:
                // Set Hospital Goal
                break;
            case 2:
                // Set Mental Health Goal
                break;
            
            case 3:
                // Set Food Goal
                break;
            case 4:
                // Set Sleep Goal
                break;
             
        }
    }

    private void SetHealthGoal(NPCData npcData)
    {
        
        //npcData.agent.SetDestination();
    }

    private void SetMentalHealthGoal(NPCData npcData)
    {
        
    }

    private void SetHungerGoal(NPCData npcData)
    {
        //NPCLocations.instance.
    }

    private void SetSleepGoal(NPCData npcData)
    {
        if (npcData.hasHome)
        {
            npcData.agent.SetDestination(_npcLocationsSo.homeList[npcData.homeIdentifier].location);   
        }
    }
    
}
