using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    protected override void Start()
    {
        base.Start();
        _buildingManager.commercialBuildings.Add(this);
    }
}
