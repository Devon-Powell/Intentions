using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// example child class of GenerateNPCNames feature to show how we define its dependency
// on housing and family data these two other features 
public class FeatureDependencyGenerateNPCNames : FeatureDependency
{
    public override void init()
    {
        base.init();
        //NPCNameGenerator.instantiateFeature();
    }

    // public override bool canInitialize
    // {
    //     get
    //     {
    //         return base.canInitialize &&
    //                HouseGenerator.hasHouseData &&
    //                Data.getFamilyData() != null;
    //     }
    // }
}