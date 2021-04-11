using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingManager _buildingManager;
    public string buildingName;
    public Vector3 buildingLocation;
    public List<GameObject> interactableObjects;
    
    protected virtual void Awake()
    {
        if(_buildingManager == null)
            _buildingManager = (BuildingManager) FindObjectOfType(typeof(BuildingManager));
    }
    
    protected virtual void Start()
    {
        _buildingManager.buildingList.Add(this);
        buildingLocation = transform.position;
    }
}
