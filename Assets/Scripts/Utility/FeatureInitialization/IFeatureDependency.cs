using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public interface IFeatureDependency
{
    bool isInitialized { get; }
    bool canInitialize { get; }
    void init();
}