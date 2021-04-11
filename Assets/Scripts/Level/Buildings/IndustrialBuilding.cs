using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    protected override void Start()
    {
        base.Start();
        _buildingManager.industrialBuildings.Add(this);
    }
}
