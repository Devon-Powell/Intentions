using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public int maxResidents;
    public int maxFamilies;
    public List<NPCData> currentResidents;
    
    protected override void Awake()
    {
        base.Awake();
        BuildingManager.buildingDataSo.residentialBuildings.Add(this);
    }
}
