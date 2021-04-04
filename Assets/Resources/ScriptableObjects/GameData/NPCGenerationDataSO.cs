using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerationDataSO : MonoBehaviour
{
    [Header("Generation Affectors")]
    public float employedRatio;
    public float homelessRatio;
    public float lastNameRatio;

    public AnimationCurve ageCurve;
    public AnimationCurve healthCurve;
    public AnimationCurve mentalHealthCurve;
    
    [Header("NPC Names")]
    public List<string> maleNames;
    public List<string> femaleNames;
    public List<string> lastNames;
}
