using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreationalBuilding : Building
{
    protected override void Start()
    {
        base.Start();
        _buildingManager.recreationalBuildings.Add(this);
    }
}
