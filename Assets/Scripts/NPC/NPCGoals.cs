using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NPCGoals : MonoBehaviour
{
    private NavMeshAgent agent;
    public NPCStats npcStats;
    public Interactables interactables;
    
    public Interactable currentInteractable;

    public StatType currentNeed;
    
    public bool hasGoal;
    public bool isAtTarget;
    public bool isInteracting;
    
    private void Start()
    {
        interactables = (Interactables) FindObjectOfType(typeof(Interactables));
        npcStats = (NPCStats) GetComponent(typeof(NPCStats));
        agent = (NavMeshAgent) GetComponent(typeof(NavMeshAgent));

        InvokeRepeating(nameof(CheckGoalState), 0.1f, 0.1f);
    }

    private void CheckGoalState()
    {
        if (!hasGoal) SelectTargetGoal();
        
        if (hasGoal && !PathingState()) 
            agent.SetDestination(currentInteractable.transform.position);

        if (hasGoal  && PathingState() && !isInteracting)
        {
            isInteracting = true;
            StartCoroutine(Interaction(currentInteractable.interactionTime));
        }

        if (isInteracting)
        {
            if (Vector3.Distance(transform.position, currentInteractable.transform.position) >
                     agent.stoppingDistance)
            {
                //Debug.Log("Too Far");
                InteractionInterrupted();
            }
        }
    }

    private void SelectTargetGoal()
    {
        hasGoal = true;
        currentNeed = npcStats.FindCurrentNeed();

        int i;
        switch (currentNeed)
        {
            case StatType.Hunger:
                i = Random.Range(0, interactables.hungerInteractables.Count);
                currentInteractable = interactables.hungerInteractables[i];
                break;
            case StatType.Energy:
                i = Random.Range(0, interactables.energyInteractables.Count);
                currentInteractable = interactables.energyInteractables[i];
                break;
            case StatType.Hygiene:
                i = Random.Range(0, interactables.hygieneInteractables.Count);
                currentInteractable = interactables.hygieneInteractables[i];
                break;
            case StatType.Restroom:
                i = Random.Range(0, interactables.restroomInteractables.Count);
                currentInteractable = interactables.restroomInteractables[i];
                break;
            case StatType.Social:
                i = Random.Range(0, interactables.socialInteractables.Count);
                currentInteractable = interactables.socialInteractables[i];
                break;
            case StatType.Health:
                break;
            case StatType.Sanity:
                break;
            case StatType.Mood:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        agent.SetDestination(currentInteractable.transform.position);
    }

    private IEnumerator Interaction(int time)
    {
        foreach (var modifier in currentInteractable.interactableStatModifiers)
        {
            npcStats.ChangeStatModifiers(modifier.statType, modifier.value);
        }
        
        yield return new WaitForSeconds(time);

        InteractionStopped();
        InteractionComplete();
    }

    private void InteractionStopped()
    {
        StopCoroutine(nameof(Interaction));
        npcStats.ResetStatModifiers();
        isInteracting = false;
    }
    
    private void InteractionInterrupted()
    {
        agent.SetDestination(currentInteractable.transform.position);
    }

    private void InteractionComplete()
    {

        hasGoal = false;
    }
    
    private bool PathingState()
    {
        if (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            if (!agent.hasPath || Math.Abs(agent.velocity.sqrMagnitude) < Utility.tolerance)
                return true;
        }
        return false;
    }
    
}
