using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    protected override void Awake()
    {
        base.Awake();
        _buildingManager.industrialBuildings.Add(this);
    }
}
