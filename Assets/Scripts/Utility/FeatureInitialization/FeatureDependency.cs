using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// super class implementing IFeatureDependency interface
public class FeatureDependency : IFeatureDependency
{
    /// <summary>
    /// Returns true when the feature is initialized successfully
    /// </summary>
    public virtual bool isInitialized { get; protected set; }

    /// <summary>
    /// Main entry for the feature
    /// </summary>
    public virtual void init()
    {
        isInitialized = true;
    }

    /// <summary>
    /// Set criteria needed for initialization
    /// </summary>
    public virtual bool canInitialize
    {
        get { return !isInitialized; }
    }
}