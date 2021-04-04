using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string name;
    public Vector3 location;
    public List<GameObject> interactableObjects;
    
    protected virtual void Awake()
    {
        
    }
}
