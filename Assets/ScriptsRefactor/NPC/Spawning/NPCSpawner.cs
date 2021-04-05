using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    private BuildingManager _buildingManager;
    
    [SerializeField] private GameObject npcPrefab;
    
    private void Start()
    {
        if(_buildingManager == null)
            _buildingManager = (BuildingManager) FindObjectOfType(typeof(BuildingManager));
        
        SpawnBuildingResidents();
    }

    private void SpawnBuildingResidents()
    {
        for (int i = 0; i < _buildingManager.residentialBuildings.Count; i++)
        {
            for (int j = 0; j < _buildingManager.residentialBuildings[i].maxResidents; j++)
            {
                SpawnNewNPC(i);
            }
        }
    }

    private void SpawnNewNPC(int buildingID)
    {
        Vector3 spawnPosition = new Vector3(
            _buildingManager.residentialBuildings[buildingID].buildingLocation.x,
            _buildingManager.residentialBuildings[buildingID].buildingLocation.y,
            _buildingManager.residentialBuildings[buildingID].buildingLocation.z);

        spawnPosition.x += Random.Range(-10, 10);
        spawnPosition.z += Random.Range(-10, 10);

        GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
    }
}
