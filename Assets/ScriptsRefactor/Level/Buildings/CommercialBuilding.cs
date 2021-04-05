using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    protected override void Awake()
    {
        base.Awake();
        _buildingManager.commercialBuildings.Add(this);
    }
}
