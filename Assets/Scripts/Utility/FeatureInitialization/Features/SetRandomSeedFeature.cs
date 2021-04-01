using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSeedFeature : FeatureDependency
{
    public override void init()
    {
        base.init();
        //SetRandomSeed.instantiateFeature();
    }

    public override bool canInitialize
    {
        get
        {
            return base.canInitialize;
        }
    }
}
