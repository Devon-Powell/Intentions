using UnityEngine;

[System.Serializable]
public class Stat
{
    public StatType type;

    [Range(0, 100)] public float value;
    [Range(-10, 10)] public float modifier;
    [Range(-10, 10)] public float defaultModifier;
    public AnimationCurve importanceCurve;
    public float impact;
}
