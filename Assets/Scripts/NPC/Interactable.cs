using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Interactables _interactables;

    
    [Header("Interaction Data")] 
    public int interactionTime;
    public bool isInteractable;

    public List<InteractableStatModifier> interactableStatModifiers;

    [System.Serializable]
    public class InteractableStatModifier
    {
        public StatType statType;
        public float value;
    }

    private void OnEnable()
    {
        foreach (var statModifier in interactableStatModifiers)
        {
            if (statModifier.value > 0)
            {
                switch (statModifier.statType)
                {
                    case StatType.Hunger:
                        _interactables.hungerInteractables.Add(this);
                        break;
                    case StatType.Energy:
                        _interactables.energyInteractables.Add(this);
                        break;
                    case StatType.Hygiene:
                        _interactables.hygieneInteractables.Add(this);
                        break;
                    case StatType.Restroom:
                        _interactables.restroomInteractables.Add(this);
                        break;
                    case StatType.Social:
                        _interactables.socialInteractables.Add(this);
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
            }
        }
    }

    private void OnDisable()
    {
        foreach (var statModifier in interactableStatModifiers)
        {
            if (statModifier.value > 0)
            {
                switch (statModifier.statType)
                {
                    case StatType.Hunger:
                        _interactables.hungerInteractables.Remove(this);
                        break;
                    case StatType.Energy:
                        _interactables.energyInteractables.Remove(this);
                        break;
                    case StatType.Hygiene:
                        _interactables.hygieneInteractables.Remove(this);
                        break;
                    case StatType.Restroom:
                        _interactables.restroomInteractables.Remove(this);
                        break;
                    case StatType.Social:
                        _interactables.socialInteractables.Remove(this);
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
            }
        }
    }
}
