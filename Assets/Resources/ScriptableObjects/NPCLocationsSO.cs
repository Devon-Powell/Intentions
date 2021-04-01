using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCLocations", menuName = "ScriptableObjects/NPCLocations")]
public class NPCLocationsSO : ScriptableObject
{    
    public List<Homes> homeList;
    public List<Jobs> jobList;
    public List<Recreationals> recreational;
    public List<Shops> shopList;

    public List<ResidentialData> residentialList;
    public List<BusinessData> businessList;
    public List<ServicesData> servicesList;
    public List<RecreationalData> recreationalList;
    
    [System.Serializable]
    public class Homes
    {
        public Vector3 location;
        public int type;
        public int maxResidents;
    }

    [System.Serializable]
    public class Jobs
    {
        public Vector3 location;
        public int type;
        public int maxEmployees;
        //public int workShift;
    }

    [System.Serializable]
    public class Recreationals
    {
        public Vector3 location;
        public int type;
    }

    [System.Serializable]
    public class Shops
    {
        public Vector3 location;
        public int type;
    }
}
