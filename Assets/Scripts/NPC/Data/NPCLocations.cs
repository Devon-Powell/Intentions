using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class NPCLocations
{
    private static NPCLocationsSO _npcLocationsSo;


    public static void Init()
    {
        
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        FindHomes();
        FindBusiness();
        FindShops();
    }

    private static void FindHomes()
    {
        _npcLocationsSo.homeList.Clear();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Homes"))
        {
            NPCLocationsSO.Homes home = new NPCLocationsSO.Homes();
            home.location = go.transform.position;
            home.type = Random.Range(0, 4);
            home.maxResidents = home.type * 2;
            _npcLocationsSo.homeList.Add(home);
        }
    }

    private static void FindBusiness()
    {
        _npcLocationsSo.jobList.Clear();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Jobs"))
        {
            NPCLocationsSO.Jobs job = new NPCLocationsSO.Jobs();
            job.location = go.transform.position;
            job.type = Random.Range(0, 4);
            job.maxEmployees = job.type * 2;
            _npcLocationsSo.jobList.Add(job);
        }
    }

    private static void FindShops()
    {
        _npcLocationsSo.shopList.Clear();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Shops"))
        {
            NPCLocationsSO.Shops shop = new NPCLocationsSO.Shops();
            shop.location = go.transform.position;
            shop.type = Random.Range(0, 4);
            _npcLocationsSo.shopList.Add(shop);
        }
    }
}
