using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NPCStats : MonoBehaviour
{
    public NavMeshAgent agent;
    public float currentHappiness;
    public float moveSpeedMin, moveSpeedMax, currentMoveSpeed;

    private float statMin, statMax;

    public List<Stat> maintenanceStats;
    public List<Stat> passiveStats;

    public Stat currentNeed;
    public float highestImpact;

    private void Start()
    {
        statMin = 0;
        statMax = 100;

        foreach (var stat in maintenanceStats)
        {
            //stat.defaultModifier = Random.Range(-0.2f, -0.1f);
            stat.value = Random.Range(50, 100);
            stat.modifier = stat.defaultModifier;
        }
        
        InvokeRepeating(nameof(CalculateCurrentStats), 0.1f, 0.1f);
    }
    
    private void CalculateCurrentStats()
    {
        StatDrain();
        CalculateTotalHappiness();
        CalculateCurrentSpeed();
    }

    public void ChangeStatModifiers(StatType type, float value)
    {
        foreach (var stat in maintenanceStats)
        {
            if (stat.type == type)
                stat.modifier += value;
        }
    }

    public void ResetStatModifiers()
    {
        foreach (var stat in maintenanceStats)
        {
            stat.modifier = stat.defaultModifier;
        }
    }

    private void StatDrain()
    {
        foreach (var stat in maintenanceStats)
        {
            stat.value = Mathf.Clamp(stat.value += stat.modifier, statMin, statMax);
            stat.impact = CalculateHappinessImpact(stat.importanceCurve, stat.value);
        }
    }

    private void CalculateCurrentSpeed()
    {
        float impact = CalculateHappinessImpact(currentNeed.importanceCurve, currentNeed.value);
        currentMoveSpeed = Utility.ConvertRange(impact, 0, 100, moveSpeedMin, moveSpeedMax);
        agent.speed = currentMoveSpeed;
    }

    private void CalculateTotalHappiness()
    {
        currentHappiness = 0;
        foreach (var stat in maintenanceStats)
        {
            currentHappiness += CalculateHappinessImpact(stat.importanceCurve, stat.value);
        }
        currentHappiness = Utility.ConvertRange(currentHappiness, 0, maintenanceStats.Count * 100, 0, 100);
        currentHappiness = 100 - currentHappiness;
    }
    
    public float CalculateHappinessImpact(AnimationCurve curve, float stat)
    {
        return curve.Evaluate(stat / 100) * 100;
    }

    public StatType FindCurrentNeed()
    {
        highestImpact = 0;
        StatType type = StatType.Hunger;
        
        foreach (var stat in maintenanceStats)
        {
            float impact = CalculateHappinessImpact(stat.importanceCurve, stat.value) -
                           CalculateHappinessImpact(stat.importanceCurve, stat.value + 1);

            if (impact > highestImpact)
            {
                highestImpact = impact;
                currentNeed = stat;
                type = stat.type;
            }
        }
        return type;
    }
}
