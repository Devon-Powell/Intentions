using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public enum BuildingState
    {
        Abandoned, Destroyed, Operational
    }

    public enum BuildingAccessAvailability
    {
        Private, Public
    }

    public enum BuildingType
    {
        Commercial, Industrial, Recreational, Residential
    }
    
    public class Building
    {
        public string buildingName;
        public Vector3 buildingLocation;
        public List<GameObject> interactableObjects;

        [Header("CommercialData")]
        
        [Header("IndustrialData")]
        
        [Header("RecreationalData")]
        
        [Header("ResidentialData")]
        public int maxResidents;
        public int maxFamilies;
        public List<NPCData> currentResidents;
    }
}
