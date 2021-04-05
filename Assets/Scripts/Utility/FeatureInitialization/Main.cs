using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //[SerializeField] private SetRandomSeed _setRandomSeed;
    //[SerializeField] private NPCLocations _npcLocations;
    // [SerializeField] private NPCNames _npcNames;
    // [SerializeField] private NPCSpawnFamily _npcSpawnFamily;
    // [SerializeField] private NPCDataGenerator _npcDataGenerator;
    // [SerializeField] private NPCDataHandler _npcDataHandler;
    // [SerializeField] private CharacterSpawner _characterSpawner;
    [SerializeField] private string[] classNames;

    private void Awake()
    {
        //NPCLocations.Init();
        for (int i = 0; i < classNames.Length; i++)
        {
            string className = classNames[i];
            System.Type classType = System.Type.GetType(className);
            FeatureDependency dependency = System.Activator.CreateInstance(classType) as FeatureDependency;
            FeatureInitializer.initFeatures.Add(dependency);
            
        }
        
        //string className = "FeatureDependencyNPCLocations";
        //System.Type classType = System.Type.GetType(className);
        //FeatureDependency npcLocationFeatureDependency = System.Activator.CreateInstance(classType) as FeatureDependency;
        //FeatureInitializer.initFeatures.Add(npcLocationFeatureDependency);
    }

    private void Start()
    {
        StartCoroutine(FeatureInitializer.startup());
    }   
}
