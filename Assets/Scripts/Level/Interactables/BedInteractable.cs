using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : SceneInteractable
{
    protected override void Awake()
    {
        base.Awake();
        ResidentialBuilding residentialBuilding = (ResidentialBuilding) building.transform.GetComponent(typeof(ResidentialBuilding));
        residentialBuilding.maxResidents++;
    }
}
