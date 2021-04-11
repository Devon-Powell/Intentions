using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private BuildingManager _buildingManager;
    [SerializeField] private NPCDataGenerator _npcDataGenerator;
    
    [SerializeField] private GameObject npcPrefab;
    
    public void Start()
    {
        if(_buildingManager == null)
            _buildingManager = (BuildingManager) FindObjectOfType(typeof(BuildingManager));

        if (_npcDataGenerator == null)
            _npcDataGenerator = (NPCDataGenerator) FindObjectOfType(typeof(NPCDataGenerator));
         
        SpawnBuildingResidents();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBuildingResidents();
        }
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
        _npcDataGenerator.AssignCharacterData((NPCData) npc.GetComponent(typeof(NPCData)));
    }
}
