using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    private GameObject go;
    private Renderer rend;

    public Gradient gradient;


    private void Start()
    {
        go = this.gameObject;
        rend = (Renderer)this.gameObject.GetComponent(typeof(Renderer));
    }

    private void Update()
    {
        //float happinessNormalized = Utility.ConvertRange(npcStats.currentHappiness, 0, 100, 0, 1);
        //rend.material.SetColor("_BaseColor", gradient.Evaluate(happinessNormalized));
    }
}
