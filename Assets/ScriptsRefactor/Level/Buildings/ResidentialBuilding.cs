using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public int maxResidents;
    public int maxFamilies;
    //public List<NPCData> currentResidents;
    
    protected override void Awake()
    {
        base.Awake();
        _buildingManager.residentialBuildings.Add(this);
    }
}
