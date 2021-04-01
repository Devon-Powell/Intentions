using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureDependencyNPCLocations : FeatureDependency
{
    public override void init()
    {
        base.init();
        NPCLocations.Init();
    }

    public override bool canInitialize
    {
        get
        {
            return base.canInitialize;
        }
    }
}
