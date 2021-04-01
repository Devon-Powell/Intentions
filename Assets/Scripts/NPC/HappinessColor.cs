using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HappinessColor : MonoBehaviour
{
    public NPCStats npcStats;
    public Gradient colorGradient;
    
    private Renderer rend;
    
    void Start()
    {
        rend = (Renderer) this.gameObject.GetComponent(typeof(Renderer));
    }

    // Update is called once per frame
    void Update()
    {
        float happinessNormalized = Utility.ConvertRange(npcStats.currentHappiness, 0, 100, 0, 1);
        rend.material.SetColor("_BaseColor", colorGradient.Evaluate(happinessNormalized));
}
}
