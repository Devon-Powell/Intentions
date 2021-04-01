using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCDataHandler : MonoBehaviour
{
    public NPCData _npcData;
    public NPCDataGenerator _npcDataGenerator;

    private void Awake()
    {
        _npcData = this.gameObject.GetComponent<NPCData>();
        _npcDataGenerator = GameObject.FindGameObjectWithTag("NPCGenerator").GetComponent<NPCDataGenerator>();

        _npcData.go = this.gameObject;
        _npcData.agent = this.gameObject.GetComponent<NavMeshAgent>();
        _npcData.character = this.gameObject.GetComponent<ThirdPersonCharacter>();

        GetCharacterData();
    }

    private void GetCharacterData()
    {
        _npcData = _npcDataGenerator.AssignCharacterData(_npcData);
    }
}
