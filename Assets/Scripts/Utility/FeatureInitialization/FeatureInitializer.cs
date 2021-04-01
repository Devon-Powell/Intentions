using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// this is where we actually initialize everything 
// static class that goes through a list of all features in game
// initialize them according to the dependencies they have defined in
// their own FeatureDependencyClass
// 
// As we add new features, we only need to draft that feature's dependency class
// like FeatureDependencyGenerateNPCNames.cs
// and add that to the list in this class
public static class FeatureInitializer
{
    /// <summary>
    /// List of features our game needs to start
    /// </summary>
    public static List<IFeatureDependency> initFeatures = new List<IFeatureDependency>();

    
    // goes through the list of features, only initialize them if their dependency is met
    // it does this through multiple passes. 
    // feature whose dependencies are not met are essentially deferred their init() call
    // conclude until all features are initialized
    public static IEnumerator startup()
    {
        while (!isDone)
        {
            for (int i = 0; i < initFeatures.Count; ++i)
            {
                IFeatureDependency featureDependency = initFeatures[i];

                if (featureDependency != null)
                {
                    if (!featureDependency.isInitialized && featureDependency.canInitialize)
                    {
                        featureDependency.init();
                    }
                }
            }

            yield return null;
        }
    }


    // returns true if every feature is initiazlied
    public static bool isDone
    {
        get
        {
            for (int i = 0; i < initFeatures.Count; ++i)
            {
                if (!initFeatures[i].isInitialized)
                {
                    return false;
                }
            }

            return true;
        }
    }
}