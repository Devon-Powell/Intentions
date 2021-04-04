using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingManager
{
    public static BuildingDataSO buildingDataSo;

    private static void Awake()
    {
        buildingDataSo = Resources.Load<BuildingDataSO>("ScriptableObjects/GameData");
        buildingDataSo.buildingList.Clear();
        buildingDataSo.commercialBuildings.Clear();
        buildingDataSo.industrialBuildings.Clear();
        buildingDataSo.recreationalBuildings.Clear();
        buildingDataSo.residentialBuildings.Clear();
    }
}
