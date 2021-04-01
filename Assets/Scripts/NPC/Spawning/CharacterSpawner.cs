using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public NPCSpawnFamily _npcSpawnFamily;
    private static NPCLocationsSO _npcLocationsSo;
    
    private GameObject npcPrefab;

    private void Awake()
    {
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        if (_npcSpawnFamily == null) _npcSpawnFamily = this.gameObject.GetComponent<NPCSpawnFamily>();

        npcPrefab = Resources.Load<GameObject>("Prefabs/NPC/NPCPrefab");
    }

    private void Start()
    {
        SpawnNPC();

        SpawnFamilyMember();
    }

    private void SpawnNPC()
    {
        for (int i = 0; i < _npcSpawnFamily.familyDataList.Count; i++)
        {
            Vector3 homeLocation = new Vector3( _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.x + Random.Range(-10, 10),
                _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.y,
                _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.z + Random.Range(-10, 10));
            GameObject npc = Instantiate(npcPrefab, homeLocation, Quaternion.identity);
            NPCData data = npc.gameObject.GetComponent<NPCData>();
            data.homeIdentifier = i;
        }
    }

     private void SpawnFamilyMember()
     {
         for (int i = 0; i < _npcSpawnFamily.familyDataList.Count; i++)
         {
             for (int j = 0; j < _npcSpawnFamily.familyDataList[i].memberAmount; j++)
             {
                 Vector3 homeLocation = new Vector3( _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.x + Random.Range(-10, 10),
                     _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.y,
                     _npcLocationsSo.homeList[_npcSpawnFamily.familyDataList[i].familyHomeIdentifier].location.z + Random.Range(-10, 10));
                 GameObject npc = Instantiate(npcPrefab, homeLocation, Quaternion.identity);
                 NPCData data = npc.gameObject.GetComponent<NPCData>();
                 data.homeIdentifier = i;
             }
         }
    }




}
