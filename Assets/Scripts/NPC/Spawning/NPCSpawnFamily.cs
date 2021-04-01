using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnFamily : MonoBehaviour
{
    private static NPCLocationsSO _npcLocationsSo;
    public NPCNames _npcNames;

    public List<FamilyData> familyDataList;

    [System.Serializable]
    public class FamilyData
    {
        public string familyName;
        public int familyHomeIdentifier;
        public int memberAmount;
    }

    public void Start()
    {
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        _npcNames = this.gameObject.GetComponent<NPCNames>();

        GenerateFamilies();
    }

    private void GenerateFamilies()
    {
        int familyAmount = _npcLocationsSo.homeList.Count;

        for (int i = 0; i < familyAmount; i++)
        {
            FamilyData familyData = new FamilyData
            {
                familyName = _npcNames.lastNames[Random.Range(0, _npcNames.lastNames.Count)],
                familyHomeIdentifier = i,
                memberAmount = _npcLocationsSo.homeList[i].type * 4
            };
            familyDataList.Add(familyData);
        }
    }
}
