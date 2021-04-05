using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreationalBuilding : Building
{
    protected override void Awake()
    {
        base.Awake();
        _buildingManager.recreationalBuildings.Add(this);
    }
}
