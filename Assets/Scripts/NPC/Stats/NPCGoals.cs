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
    public InteractableObjects interactableObjects;
    
    public InteractableObject currentInteractable;

    public StatType currentNeed;
    
    public bool hasGoal;
    public bool isAtTarget;
    public bool isInteracting;
    
    private void Awake()
    {
        interactableObjects = (InteractableObjects) FindObjectOfType(typeof(InteractableObjects));
        npcStats = (NPCStats) GetComponent(typeof(NPCStats));
        agent = (NavMeshAgent) GetComponent(typeof(NavMeshAgent));
    }

    private void Start()
    {
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
            StartCoroutine(Interaction(currentInteractable.activityDuration));
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
        // switch (currentNeed)
        // {
        //     case StatType.Hunger:
        //         i = Random.Range(0, interactableObjects.hungerInteractables.Count);
        //         currentInteractable = interactableObjects.hungerInteractables[i];
        //         break;
        //     case StatType.Energy:
        //         i = Random.Range(0, interactableObjects.energyInteractables.Count);
        //         currentInteractable = interactableObjects.energyInteractables[i];
        //         break;
        //     case StatType.Hygiene:
        //         i = Random.Range(0, interactableObjects.hygieneInteractables.Count);
        //         currentInteractable = interactableObjects.hygieneInteractables[i];
        //         break;
        //     case StatType.Restroom:
        //         i = Random.Range(0, interactableObjects.restroomInteractables.Count);
        //         currentInteractable = interactableObjects.restroomInteractables[i];
        //         break;
        //     case StatType.Social:
        //         i = Random.Range(0, interactableObjects.socialInteractables.Count);
        //         currentInteractable = interactableObjects.socialInteractables[i];
        //         break;
        //     case StatType.Health:
        //         break;
        //     case StatType.Sanity:
        //         break;
        //     case StatType.Mood:
        //         break;
        //     default:
        //         throw new ArgumentOutOfRangeException();
        // }
        if (currentInteractable != null)
            agent.SetDestination(currentInteractable.transform.position);
        else
            hasGoal = false;
    }

    private IEnumerator Interaction(float time)
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
