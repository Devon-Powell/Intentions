using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCGenerationDataSO", menuName = "ScriptableObjects/NPCGenerationData")]
public class NPCGenerationDataSO : ScriptableObject
{
    [Header("Generation Affectors")]
    [Range(0, 1)] public float employedRatio;
    [Range(0, 1)] public float homelessRatio;
    [Range(0, 1)] public float lastNameRatio;

    public AnimationCurve ageCurve;
    public AnimationCurve healthCurve;
    public AnimationCurve mentalHealthCurve;
    
    [Header("NPC Names")]
    public List<string> maleNames;
    public List<string> femaleNames;
    public List<string> lastNames;
}
