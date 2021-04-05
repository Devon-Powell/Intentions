using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetRandomSeedSP", menuName = "ScriptableObjects/SetRandomSeed")]
public class SetRandomSeedSO : ScriptableObject
{
    public bool useStringSeed;
    public string stringSeed = "seed string";

    public bool randomizeSeed;
    public int seed;

    public float[] values;
}
