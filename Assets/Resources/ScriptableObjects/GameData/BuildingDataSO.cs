using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDataSO", menuName = "ScriptableObjects/BuildingData")]
public class BuildingDataSO : ScriptableObject
{
    public List<Building> buildingList;
    public List<CommercialBuilding> commercialBuildings;
    public List<IndustrialBuilding> industrialBuildings;
    public List<RecreationalBuilding> recreationalBuildings;
    public List<ResidentialBuilding> residentialBuildings;

    private void OnEnable()
    {
        buildingList.Clear();
        commercialBuildings.Clear();
        industrialBuildings.Clear();
        residentialBuildings.Clear();
        residentialBuildings.Clear();
    }
}
