using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public int maxResidents;
    public int maxFamilies;
    //public List<NPCData> currentResidents;
    
    protected override void Start()
    {
        base.Start();
        _buildingManager.residentialBuildings.Add(this);
    }
}
